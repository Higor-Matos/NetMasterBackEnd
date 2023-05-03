using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using NetMaster.Domain.Models.Results;
using Newtonsoft.Json.Linq;

namespace NetMaster.Repository.Local.Powershell.Software
{
    public class GetInstalledProgramsRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel<InstalledProgramsResponse>> ExecCommand(RepositoryPowerShellParamModel param)
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

            Func<string, InstalledProgramsResponse> convertOutput = (jsonOutput) =>
            {
                JObject resultJson = JObject.Parse(jsonOutput);
                var installedPrograms = resultJson["Programs"].ToObject<List<InstalledProgram>>();
                return new InstalledProgramsResponse
                {
                    InstalledPrograms = installedPrograms,
                    IpAddress = resultJson["IpAddress"].ToString(),
                    PSComputerName = resultJson["PSComputerName"].ToString(),
                    Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                };
            };

            return await base.ExecCommand(param, command, convertOutput);
        }
    }
}
