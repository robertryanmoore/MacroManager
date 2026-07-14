<#
    Publishes MacroManager as a self-contained, single-file win-x64 build and
    compiles the Inno Setup installer around it.

    Prerequisites:
      - .NET 8 SDK (for dotnet publish)
      - Inno Setup 6 (ISCC.exe) - https://jrsoftware.org/isinfo.php
        Install with: winget install --id JRSoftware.InnoSetup
#>

$ErrorActionPreference = "Stop"

$repoRoot = Split-Path -Parent $PSScriptRoot
$project = Join-Path $repoRoot "MacroManager\MacroManager.csproj"
$issScript = Join-Path $PSScriptRoot "MacroManager.iss"

Write-Host "Publishing MacroManager (Release, win-x64, self-contained, single file)..." -ForegroundColor Cyan
dotnet publish $project -c Release -r win-x64 --self-contained true
if ($LASTEXITCODE -ne 0) { throw "dotnet publish failed" }

$isccPath = (Get-Command ISCC.exe -ErrorAction SilentlyContinue).Source
if (-not $isccPath) {
    $candidatePaths = @(
        "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe",
        "${env:ProgramFiles}\Inno Setup 6\ISCC.exe",
        "${env:LocalAppData}\Programs\Inno Setup 6\ISCC.exe"
    )
    $isccPath = $candidatePaths | Where-Object { Test-Path $_ } | Select-Object -First 1
}

if (-not $isccPath) {
    throw "ISCC.exe (Inno Setup compiler) was not found. Install Inno Setup 6 first, e.g.:`n  winget install --id JRSoftware.InnoSetup"
}

Write-Host "Compiling installer with $isccPath..." -ForegroundColor Cyan
& $isccPath $issScript
if ($LASTEXITCODE -ne 0) { throw "ISCC compilation failed" }

Write-Host "Done. Installer is in installer\Output\MacroManagerSetup.exe" -ForegroundColor Green
