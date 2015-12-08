# Much taken from https://github.com/BarryThePenguin/SparkleShare
$base_dir = resolve-path .
$src_dir = "$base_dir\VigilantCupcake"
$package_dir = "$base_dir\packages"
$build_dir = "$src_dir\build"
$nuspec_dir = "$src_dir"
$temp_dir = "$build_dir\Temp"
$release_dir = "$base_dir\Releases"
$sharedAssemblyInfo = "$src_dir\Properties\AssemblyInfo.cs"
$squirrel = Get-ChildItem "$package_dir\squirrel.windows.*\tools\Squirrel.exe"
$syncReleases = Get-ChildItem "$package_dir\squirrel.windows.*\tools\SyncReleases.exe"

function Exec #Taken from psake https://github.com/psake/psake
{
	[CmdletBinding()]
	param(
		[Parameter(Position=0,Mandatory=1)][scriptblock]$cmd,
		[Parameter(Position=1,Mandatory=0)][string]$errorMessage = ($msgs.error_bad_command -f $cmd)
	)
	& $cmd
	if ($lastexitcode -ne 0) {
		throw ("Exec: " + $errorMessage)
	}
}

function Create-Package($project, $version) {
	Create-Directory $temp_dir
	Copy-Files "$nuspec_dir\$project.nuspec" $temp_dir

	Try {
		Replace-Content "$nuspec_dir\$project.nuspec" '0.0.0' $version
		Exec {nuget pack "$nuspec_dir\$project.nuspec" -OutputDirectory "$build_dir" -BasePath "$base_dir" -Version $version -Properties Platform=AnyCPU -Properties Configuration=Release }
	}
	Finally {
		Move-Files "$temp_dir\$project.nuspec" $nuspec_dir
	}
}

function Get-BuildVersion {
	$version = Get-SharedVersion
	$buildNumber = $env:APPVEYOR_BUILD_NUMBER

	if ($env:APPVEYOR_REPO_TAG -ne "True" -And $buildNumber -ne $null) {
		$version += "-build-" + $buildNumber.ToString().PadLeft(5, '0')
	}

	return $version
}

function Get-SharedVersion {
	$line = Get-Content "$sharedAssemblyInfo" | where {$_.Contains("AssemblyVersion")}
	$line.Split('"')[1]
}

function Create-Directory($dir) {
	New-Item -Path $dir -Type Directory -Force > $null
}

function Copy-Files($source, $destination) {
	Copy-Item "$source" $destination -Force > $null
}

function Move-Files($source, $destination) {
	Move-Item "$source" $destination -Force > $null
}


function Replace-Content($file, $pattern, $substring) {
	(gc $file) -Replace $pattern, $substring | sc $file
}

if ($env:APPVEYOR) {
	$base_dir = $env:APPVEYOR_BUILD_FOLDER
	$token = $env:GitHubToken
}

$version = Get-BuildVersion

Write-Host "Creating package"
Create-Package "vigilantcupcake" $version

Write-Host "Syncing releases"	
if ($token) {
	Exec { .$syncReleases -releaseDir $release_dir -url "https://github.com/amweiss/vigilant-cupcake" -token $token }
} else {
	Exec { .$syncReleases -releaseDir $release_dir -url "https://github.com/amweiss/vigilant-cupcake" }
}
Write-Host "Releasifying"
Exec { .$squirrel -releasify "$build_dir\vigilantcupcake.$version.nupkg" -releaseDir $release_dir -setupIcon "$src_dir\VC2-nobg-whitecake.ico" } # -n "/a /f build/windows/app_signing.p12 /p SECRETPASSWORD"

Write-Host "Cleanup"
# Remove synced releases for github
Get-ChildItem "$release_dir.*" -exclude @('*' + $version + '*') | Remove-Item