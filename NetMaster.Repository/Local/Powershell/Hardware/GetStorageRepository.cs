using Microsoft.Management.Infrastructure;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using System.Text.Json;

namespace NetMaster.Repository.Local.Powershell.Hardware
{
    public class GetStorageRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-CimInstance -ClassName Win32_LogicalDisk | Select-Object -Property DeviceID,@{Name='Size_GB';Expression={[int]($_.Size / 1GB)}},@{Name='FreeSpace_GB';Expression={[int]($_.FreeSpace / 1GB)}},@{Name='PSComputerName';Expression={$env:COMPUTERNAME}},@{Name='Timestamp';Expression={(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')}} | ConvertTo-Json -Depth 1";
            string parameters = "";

            Func<string, string> convertOutput = (jsonOutput) =>
            {
                var storageInfo = JsonSerializer.Deserialize<StorageInfo>(jsonOutput);
                storageInfo.IpAddress = param.Ip;
                return JsonSerializer.Serialize(storageInfo);
            };

            return await base.ExecCommand<string>(param, command, convertOutput, parameters);
        }
    }
}
