// NetMaster.Repository/Implementation/System/LocalInstalledProgramsRepository.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Implementation.Powershell;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Repository.Implementation.System
{
    public class LocalInstalledProgramsRepository : BasePowershellRepository, ILocalInstalledProgramsRepository
    {
        public async Task<RepositoryResultModel<InstalledProgramsResponseModel>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = @"
                $list = @()
                $pcname = (Get-WmiObject -Class Win32_ComputerSystem).Name
                $InstalledSoftwareKey = 'SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall'
                $InstalledSoftware = [microsoft.win32.registrykey]::OpenRemoteBaseKey('LocalMachine', $pcname)
                $RegistryKey = $InstalledSoftware.OpenSubKey($InstalledSoftwareKey)
                $SubKeys = $RegistryKey.GetSubKeyNames()
                Foreach ($key in $SubKeys) {
                    $thisKey = $InstalledSoftwareKey + '\\' + $key
                    $thisSubKey = $InstalledSoftware.OpenSubKey($thisKey)
                    $obj = New-Object PSObject
                    $obj | Add-Member -MemberType NoteProperty -Name 'DisplayName' -Value $($thisSubKey.GetValue('DisplayName'))
                    $obj | Add-Member -MemberType NoteProperty -Name 'DisplayVersion' -Value $($thisSubKey.GetValue('DisplayVersion'))
                    $list += $obj
                }
                $filtered = $list | Where-Object { $_.DisplayName }
                $result = @{
                    'Programs' = $filtered;
                    'PSComputerName' = $pcname;
                    'IpAddress' = (Test-Connection -ComputerName $pcname -Count 1).IPv4Address.IPAddressToString;
                };
                $jsonResult = $result | ConvertTo-Json
                Write-Output $jsonResult
            ";

            return await ExecCommand(param, command, jsonOutput => ConvertOutput<InstalledProgramsResponseModel>(jsonOutput, param.Ip));
        }
    }
}