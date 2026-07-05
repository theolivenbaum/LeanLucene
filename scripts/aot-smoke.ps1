param(
    [string]$RuntimeIdentifier
)

if (-not $RuntimeIdentifier) {
    $RuntimeIdentifier = if ($IsLinux) { "linux-x64" } elseif ($IsMacOS) { "osx-x64" } else { "win-x64" }
}

$ErrorActionPreference = "Stop"

# Use writable NuGet cache locations (default HTTP cache may be read-only in CI/containers)
if (-not $env:NUGET_HTTP_CACHE_PATH) {
    $env:NUGET_HTTP_CACHE_PATH = Join-Path ([System.IO.Path]::GetTempPath()) "nuget-http-cache"
}
if (-not $env:NUGET_PACKAGES) {
    $env:NUGET_PACKAGES = Join-Path ([System.IO.Path]::GetTempPath()) "nuget-packages"
}

$repoRoot = Split-Path -Parent $PSScriptRoot
$project = Join-Path $repoRoot "src\devops\Rowles.LeanCorpus.Tests.AOTSmoke\Rowles.LeanCorpus.Tests.AOTSmoke.csproj"

dotnet publish $project -c Release -r $RuntimeIdentifier --self-contained true -p:PublishAot=true

$publishDirectory = Join-Path $repoRoot "src\devops\Rowles.LeanCorpus.Tests.AOTSmoke\bin\Release\net10.0\$RuntimeIdentifier\publish"
$executable = if ($RuntimeIdentifier.StartsWith("win-", [StringComparison]::OrdinalIgnoreCase)) {
    Join-Path $publishDirectory "Rowles.LeanCorpus.Tests.AOTSmoke.exe"
} else {
    Join-Path $publishDirectory "Rowles.LeanCorpus.Tests.AOTSmoke"
}

& $executable
if ($LASTEXITCODE -ne 0) {
    throw "Native AOT smoke tests failed with exit code $LASTEXITCODE."
}

Write-Host "AOT smoke tests passed." -ForegroundColor Green
