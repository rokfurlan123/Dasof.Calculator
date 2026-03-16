param(
    [ValidateSet("http", "https")]
    [string]$LaunchProfile = "https"
)

$root = Split-Path -Parent $MyInvocation.MyCommand.Path
$apiProject = Join-Path $root "src\Dasof.Calculator.Api\Dasof.Calculator.Api.csproj"
$blazorProject = Join-Path $root "src\Dasof.Calculator.Blazor\Dasof.Calculator.Blazor.csproj"

function Start-WatchWindow {
    param(
        [string]$Title,
        [string]$ProjectPath
    )

    $command = @"
Set-Location '$root'
`$Host.UI.RawUI.WindowTitle = '$Title'
dotnet watch --project '$ProjectPath' run --launch-profile $LaunchProfile
"@

    Start-Process powershell -ArgumentList "-NoExit", "-Command", $command | Out-Null
}

Start-WatchWindow -Title "Dasof API" -ProjectPath $apiProject
Start-WatchWindow -Title "Dasof Blazor" -ProjectPath $blazorProject
