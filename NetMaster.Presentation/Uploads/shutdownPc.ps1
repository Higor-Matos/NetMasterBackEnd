$cred = New-Object System.Management.Automation.PSCredential("Higor", (ConvertTo-SecureString "0028" -AsPlainText -Force))

$session = New-PSSession -ComputerName 192.168.100.15 -Credential $cred

try {
    Invoke-Command -Session $session -ScriptBlock { Stop-Computer -Force }
} catch {
}

Remove-PSSession $session

Stop-Computer -Force
