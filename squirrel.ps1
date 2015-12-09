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

function Create-Package($project, $version) {
	Create-Directory $temp_dir
	Copy-Files "$nuspec_dir\$project.nuspec" $temp_dir

	Try {
		$trimmedVersion = $version.Split('+')[0]
		Replace-Content "$nuspec_dir\$project.nuspec" '0.0.0' $trimmedVersion
		& nuget pack "$nuspec_dir\$project.nuspec" -OutputDirectory "$build_dir" -BasePath "$base_dir" -Version $trimmedVersion -Properties Platform=AnyCPU -Properties Configuration=Release
	}
	Finally {
		Move-Files "$temp_dir\$project.nuspec" $nuspec_dir
	}
}

function Get-BuildVersion {
	$version = $env:LAST_TAG
	$buildNumber = $env:APPVEYOR_BUILD_NUMBER

	if ($env:APPVEYOR_REPO_TAG -ne "True" -And $buildNumber -ne $null) {
		$version += "+" + $buildNumber.ToString()
	}

	return $version
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
	& $syncReleases -releaseDir $release_dir -url "https://github.com/amweiss/vigilant-cupcake" -token $token
} else {
	& $syncReleases -releaseDir $release_dir -url "https://github.com/amweiss/vigilant-cupcake"
}
Write-Host "Releasifying"
& $squirrel -releasify "$build_dir\vigilantcupcake.$version.nupkg" -releaseDir $release_dir -setupIcon "$src_dir\VC2-nobg-whitecake.ico" -n "/a /f vigilant.pfx /p $env:SigningPass" | Write-Output

Write-Host "Cleanup"
# Remove synced releases for github
Get-ChildItem "$release_dir.*" -exclude @('*' + $version + '*') | Remove-Item