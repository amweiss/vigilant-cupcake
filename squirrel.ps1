Properties {
    $base_dir = resolve-path .
    $src_dir = "$base_dir\VigilantCupcake"
    $package_dir = "$base_dir\packages"
    $release_dir = "$base_dir\Releases"
    $squirrel = "$package_dir\squirrel.windows.*\tools\Squirrel.exe"
    $syncReleases = "$package_dir\squirrel.windows.*\tools\SyncReleases.exe"
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

if ($env:APPVEYOR) {
    $base_dir = $env:APPVEYOR_BUILD_FOLDER
    $token = $env:GitHubToken
}

Task Installer -Depends Pack -Description "Create Squirrel release." {
    $version = Get-BuildVersion
    
    if ($token) {
        Exec { .$syncReleases -releaseDir $release_dir -url "https://github.com/amweiss/vigilant-cupcake" -token $token }
    } else {
        Exec { .$syncReleases -releaseDir $release_dir -url "https://github.com/amweiss/vigilant-cupcake" }
    }
    Exec { .$squirrel -releasify "$build_dir\vigilantcupcake.$version.nupkg" -releaseDir $release_dir -setupIcon "$src_dir\VC2-nobg-whitecake.ico" } # -n "/a /f build/windows/app_signing.p12 /p SECRETPASSWORD"

    # Remove synced releases for github
    Get-ChildItem "$release_dir.*" -exclude @('*' + $version + '*') | Remove-Item
}