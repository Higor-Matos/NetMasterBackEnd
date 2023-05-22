[CmdletBinding()]
Param(
    [Parameter(Mandatory=$false, Position=0)]
    [ValidateNotNullOrEmpty()]
    [string]$LogPath
)

# Exibe a versão do script
Write-Host ">> Script de limpeza v3.1 <<"

# Verifica se o script está sendo executado como administrador e, se não estiver, abre como administrador
Write-Host "> Verificando privilégios administrativos"
$isAdmin = ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
if (-not $isAdmin) {
    Write-Warning "Este script deve ser executado como administrador. O PowerShell será aberto como administrador agora."
    Start-Process powershell.exe "-File `"$($MyInvocation.MyCommand.Path)`"" -Verb RunAs
    Exit
}
Write-Host "Executado como administrador" -ForegroundColor GREEN

# Define a política de execução para Unrestricted
Write-Host "> Definindo política de execução"
Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Force
if ($?) {
    Write-Host "Política de execução definida como Unrestricted com sucesso." -ForegroundColor GREEN
} else {
    Write-Warning "Erro ao definir a política de execução como Unrestricted."
    Read-Host -Prompt "Pressione qualquer tecla para continuar"
}

# Função para executar comandos e exibir erros
function Execute-Command {
    param(
        [Parameter(Mandatory=$true)]
        [scriptblock]$Command
    )

    try {
        & $Command -ErrorAction Stop
    } catch {
        Write-Warning "Erro ao executar o comando: $($Command.ToString()) - $($_.Exception.Message)"
        Read-Host -Prompt "Pressione qualquer tecla para continuar"
    }
}

# Instala e executa atualizações do Windows
Write-Host "> Instalando Windows Update"
if (!(Get-PackageProvider -Name NuGet -ErrorAction SilentlyContinue)) {
    Install-PackageProvider -Name NuGet -MinimumVersion 2.8.5.201 -Force -Confirm:$false | Out-Null
}

if (!(Get-InstalledModule -Name PSWindowsUpdate -ErrorAction SilentlyContinue)) {
    Install-Module -Name PSWindowsUpdate -Force -Confirm:$false | Out-Null
}

Execute-Command {Get-WindowsUpdate -Install -IgnoreReboot -Confirm:$false}

# Atualiza todos os pacotes do Chocolatey
Write-Host "> Atualizando Chocolatey"
choco upgrade all -y

# Atualiza todos os pacotes do Winget
Write-Host "> Atualizando Winget" -ForegroundColor GREEN
Execute-Command {winget upgrade --all --accept-source-agreements --silent}

# Executa a verificação SFC
Write-Host "> Executando SFC"
Execute-Command {Start-Process -FilePath "sfc" -ArgumentList "/scannow" -Wait}
Write-Host "A verificação SFC foi concluída." -ForegroundColor GREEN

# Executa a verificação DISM
Write-Host "> Executando DISM"
$source = "C:\Windows\Logs\DISM\dism.log"
dism /Online /Cleanup-Image /CheckHealth /LogPath:$source
dism /Online /Cleanup-Image /ScanHealth /LogPath:$source
dism /Online /Cleanup-Image /RestoreHealth /LogPath:$source

# Define o papel de parede e a imagem da tela de bloqueio
Write-Host "> Configurando o papel de parede"
$WallpaperPath = "$env:USERPROFILE\Pictures\Wallpaper.png"

# Define a imagem como plano de fundo da área de trabalho
Set-ItemProperty -Path 'HKCU:\Control Panel\Desktop' -Name 'Wallpaper' -Value $WallpaperPath

# Carrega a classe SystemParametersInfo
Add-Type @"
    using System.Runtime.InteropServices;
    public class Wallpaper {
        public const int SetDesktopWallpaper = 20;
        public const int UpdateIniFile = 0x01;
        public const int SendWinIniChange = 0x02;
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public static void SetWallpaper(string path) {
            SystemParametersInfo(SetDesktopWallpaper, 0, path, UpdateIniFile | SendWinIniChange);
        }
    }
"@

# Define a imagem como plano de fundo da área de trabalho
[Wallpaper]::SetWallpaper($WallpaperPath)

# Atualiza a tela de fundo imediatamente
RUNDLL32.EXE user32.dll, UpdatePerUserSystemParameters
Start-Sleep -Seconds 1

if ($LogPath) {
    Start-Transcript -Path "$LogPath\$env:COMPUTERNAME.log" -Append
    Write-Host "Papel de parede e tela de bloqueio atualizados com sucesso."
    Stop-Transcript
}

# Força o refresh do wallpaper
[Wallpaper]::SetWallpaper("")
[Wallpaper]::SetWallpaper($WallpaperPath)


# Reinicia o explorer.exe para garantir que as mudanças sejam aplicadas
Stop-Process -ProcessName explorer -Force
Start-Process -FilePath explorer.exe -Wait

# Executa a verificação e correção de erros nos discos disponíveis
Write-Host "> Executando CHSDK"

$drives = Get-WmiObject -Query "Select * from Win32_LogicalDisk where DriveType=3"
$chkdskArgs = "/f", "/r", "/x", "/b"

foreach ($drive in $drives) {
    $driveLetter = $drive.DeviceID
    Write-Host "Verificando disco $driveLetter" -ForegroundColor Yellow
    $job = Start-Job -ScriptBlock { chkdsk @args } -ArgumentList $driveLetter, $chkdskArgs
    Wait-Job $job
    $results = Receive-Job $job
    if ($results -match 'Agendar') {
        cmd /c "echo S | chkdsk $driveLetter /f /r /x /b"
    } else {
        Write-Host "A verificação do disco $driveLetter foi concluída com sucesso." -ForegroundColor GREEN
    }
}


# Habilita a proteção do sistema, se necessário
$ProtectionStatus = (Get-ComputerRestorePoint | Where-Object { $_.DeviceObject -eq 'C:' }).ProtectionStatus
if ($ProtectionStatus -eq 'Off') {
    Enable-ComputerRestore -Drive "C:\"
    Write-Host "A proteção do sistema foi habilitada para a unidade C:." -ForegroundColor GREEN
}
# Cria o ponto de restauração
$Description = "Ponto de Restauração Criado por Script"

try {
    Checkpoint-Computer -Description $Description -RestorePointType "MODIFY_SETTINGS"
    Write-Host "Ponto de restauração criado com sucesso." -ForegroundColor GREEN
} catch {
    Write-Warning "Erro ao criar o ponto de restauração: $_"
}


# Limpeza de arquivos temporários, logs e cache

# Limpa o disco
Write-Host "> Limpando o disco"
$drives = Get-WmiObject -Query "Select * from Win32_LogicalDisk where DriveType=3"

foreach ($drive in $drives) {
    $driveLetter = $drive.DeviceID
    Write-Host "Limpando disco $driveLetter" -ForegroundColor Yellow
    $tempFile = New-TemporaryFile
    $cleanMgrScript = @"
[CmdletBinding()]
param(
    [string]`$DriveLetter
)

\$sageSetID = 1
`$StateFlags = "StateFlags" + `$sageSetID

`$selectedDrives = @(
    1,  # Temporary Internet Files
    2,  # Downloaded Program Files
    8,  # System error memory dump files
    16, # System error minidump files
    32, # Temporary files
    64  # Thumbnails
)

# Sets the selected drives for the cleanup
ForEach (`$selectedDrive in `$selectedDrives) {
    Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VolumeCaches\`$(`$selectedDrive)" -Name `$StateFlags -Value 2
}

cleanmgr.exe /sagerun:`$sageSetID /d `$DriveLetter

# Resets the StateFlags to 0
ForEach (`$selectedDrive in `$selectedDrives) {
    Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VolumeCaches\`$(`$selectedDrive)" -Name `$StateFlags -Value 0
}
"@

    Set-Content -Path $tempFile.FullName -Value $cleanMgrScript
    Execute-Command {Start-Process -FilePath "powershell.exe" -ArgumentList "-ExecutionPolicy Bypass -File `"$($tempFile.FullName)`" -DriveLetter `"$driveLetter`"" -Wait}
    Remove-Item $tempFile.FullName -Force
}

# Remove arquivos temporários do usuário
Write-Host "> Removendo arquivos temporários do usuário" -ForegroundColor Yellow
$UserTempPath = Join-Path -Path $env:TEMP -ChildPath "*"
Remove-Item -Path $UserTempPath -Recurse -Force -ErrorAction SilentlyContinue

# Remove arquivos temporários do sistema
Write-Host "> Removendo arquivos temporários do sistema" -ForegroundColor Yellow
$SystemTempPath = Join-Path -Path $env:windir -ChildPath "Temp\*"
Remove-Item -Path $SystemTempPath -Recurse -Force -ErrorAction SilentlyContinue

# Limpa logs do Windows
Write-Host "> Limpando logs do Windows" -ForegroundColor Yellow
$WindowsLogs = Join-Path -Path $env:windir -ChildPath "Logs\*"
Remove-Item -Path $WindowsLogs -Recurse -Force -ErrorAction SilentlyContinue


# Limpa a pasta Prefetch
Write-Host "> Limpando a pasta Prefetch" -ForegroundColor Yellow
$PrefetchPath = Join-Path -Path $env:windir -ChildPath "Prefetch\*"
Remove-Item -Path $PrefetchPath -Recurse -Force -ErrorAction SilentlyContinue

# Exibe informações do sistema
Write-Host "Informações do sistema:" -ForegroundColor Cyan
Get-ComputerInfo | Format-List

# Atualiza todos os aplicativos da Windows Store
Write-Host "Atualizando Windows Store"
Execute-Command {& cmd /c start powershell -Command "Get-AppXPackage -AllUsers | Foreach {Add-AppxPackage -DisableDevelopmentMode -Register `$($_.InstallLocation)\AppXManifest.xml}" -Verb RunAs}

# Esvazia a lixeira
Write-Host "Esvaziando a lixeira"
$Shell = New-Object -ComObject Shell.Application
$Recycler = $Shell.NameSpace(10)
$Recycler.Items() | ForEach-Object { Remove-Item $_.Path -Recurse -Confirm:$false }
Write-Host "Lixeira esvaziada com sucesso." -ForegroundColor GREEN

# Finaliza o script
Write-Host "A manutenção do sistema foi concluída com sucesso." -ForegroundColor GREEN
Read-Host -Prompt "Pressione qualquer tecla para fechar o script"
