param(
    [ValidatePattern('^[A-Za-z][A-Za-z0-9_]{0,63}$')]
    [string]$DatabaseName = 'DB_GROOMERS_DEMO',
    [string]$Servidor = 'localhost'
)

$ErrorActionPreference = 'Stop'
Get-Command sqlcmd -ErrorAction Stop | Out-Null
$claveDemo = [Environment]::GetEnvironmentVariable('GROOMERS_DEMO_PASSWORD')
if ([string]::IsNullOrEmpty($claveDemo) -or $claveDemo.Length -lt 12 -or $claveDemo.Length -gt 128) {
    throw 'Define GROOMERS_DEMO_PASSWORD con una contraseña propia de entre 12 y 128 caracteres.'
}

$raizProyecto = Split-Path $PSScriptRoot -Parent
if (-not ('Datos.PasswordHasher' -as [type])) {
    # El mismo hasher de .NET Framework también funciona en PowerShell moderno.
    Add-Type -Path (Join-Path $raizProyecto 'src/Datos/PasswordHasher.cs') -IgnoreWarnings -WarningAction SilentlyContinue
}
$hashAnterior = [Environment]::GetEnvironmentVariable('DemoPasswordHash')
try {
    # sqlcmd lee el hash del entorno; la contraseña no va al SQL ni a sus argumentos.
    $env:DemoPasswordHash = [Datos.PasswordHasher]::Hash($claveDemo)
    $claveDemo = $null
    & sqlcmd -S $Servidor -E -C -I -b -f 65001 -v "DatabaseName=$DatabaseName" -i (Join-Path $raizProyecto 'database/01-schema.sql')
    if ($LASTEXITCODE -ne 0) { throw 'No se pudo crear la base. Debe ser una base nueva.' }
    & sqlcmd -S $Servidor -E -C -I -b -f 65001 -v "DatabaseName=$DatabaseName" -i (Join-Path $raizProyecto 'database/02-demo.sql')
    if ($LASTEXITCODE -ne 0) { throw 'No se pudieron cargar los datos de demostración.' }
    Write-Host 'Demo creada. Usuario: admin. Usa la contraseña que definiste localmente.'
} finally {
    [Environment]::SetEnvironmentVariable('DemoPasswordHash', $hashAnterior)
    $claveDemo = $null
}
