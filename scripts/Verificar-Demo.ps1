$ErrorActionPreference = 'Stop'
$repo = Split-Path $PSScriptRoot -Parent
$instalador = Join-Path $repo 'scripts/Inicializar-Demo.ps1'
$basePrueba = 'GROOMERS_QA_' + [Guid]::NewGuid().ToString('N').Substring(0, 12)
$anterior = [Environment]::GetEnvironmentVariable('GROOMERS_DEMO_PASSWORD')
$creada = $false
try {
    [Environment]::SetEnvironmentVariable('GROOMERS_DEMO_PASSWORD', $null)
    $rechazo = $false
    try { & $instalador -DatabaseName $basePrueba } catch { $rechazo = $_.Exception.Message -match 'GROOMERS_DEMO_PASSWORD' }
    if (-not $rechazo) { throw 'El instalador aceptó una contraseña ausente.' }
    $env:GROOMERS_DEMO_PASSWORD = [Guid]::NewGuid().ToString('N') + [Guid]::NewGuid().ToString('N')
    $creada = $true
    & $instalador -DatabaseName $basePrueba
    $hashGuardado = (& sqlcmd -S localhost -E -C -b -d $basePrueba -h -1 -W -Q 'SET NOCOUNT ON; SELECT [Contraseña] FROM Usuario WHERE UsuarioID=''admin'';') | Where-Object { $_ -match '^PBKDF2-' }
    if ($LASTEXITCODE -ne 0 -or -not [Datos.PasswordHasher]::Verify($env:GROOMERS_DEMO_PASSWORD, $hashGuardado.Trim())) { throw 'La contraseña elegida no valida el hash guardado.' }
    if ([Datos.PasswordHasher]::Verify([Guid]::NewGuid().ToString('N'), $hashGuardado.Trim())) { throw 'Una contraseña distinta fue aceptada.' }
    $rechazo = $false
    try { & $instalador -DatabaseName $basePrueba } catch { $rechazo = $_.Exception.Message -match 'base nueva' }
    if (-not $rechazo) { throw 'El instalador no rechazó la base existente.' }
    $total = (& sqlcmd -S localhost -E -C -b -d $basePrueba -h -1 -W -Q 'SET NOCOUNT ON; SELECT COUNT(*) FROM Usuario;').Trim()
    if ($total -ne '1') { throw 'La segunda ejecución alteró los registros.' }
    Write-Output 'Groomers: 5 comprobaciones correctas (clave requerida, instalación, hash, rechazo incorrecta, base existente intacta).'
} finally {
    [Environment]::SetEnvironmentVariable('GROOMERS_DEMO_PASSWORD', $anterior)
    $hashGuardado = $null
    if ($creada -and $basePrueba -match '^GROOMERS_QA_[a-f0-9]{12}$') {
        & sqlcmd -S localhost -E -C -b -Q "ALTER DATABASE [$basePrueba] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [$basePrueba];"
        if ($LASTEXITCODE -ne 0) { throw 'No se pudo retirar la base temporal de verificación.' }
    }
}

