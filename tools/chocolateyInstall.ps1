$packageName = 'vigilantcupcake'
$url = 'https://cdn.rawgit.com/amweiss/vigilant-cupcake/v0.2.0/VigilantCupcake/bin/Release/VigilantCupcake.exe'
$unzipLocation = $(Split-Path -parent $MyInvocation.MyCommand.Definition)

Get-ChocolateyWebFile $packageName $unzipLocation $url
