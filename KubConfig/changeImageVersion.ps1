param (
    [string]$path,
	[string]$image
)
(Get-Content -Path ./$path/app.yml) |
ForEach-Object {$_ -Replace 'elouel/app:[0-9]*', $image } |
    Set-Content -Path ./KubConfig/app.yml
Get-Content -Path ./$path/app.yml