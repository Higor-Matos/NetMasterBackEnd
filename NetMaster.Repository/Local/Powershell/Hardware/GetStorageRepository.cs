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
            string command = "Get-CimInstance -ClassName Win32_LogicalDisk | Select-Object -Property DeviceID,@{Name='Size_GB';Expression={[int]($_.Size / 1GB)}},@{Name='FreeSpace_GB';Expression={[int]($_.FreeSpace / 1GB)}},@{Name='PSComputerName';Expression={$env:COMPUTERNAME}} | ConvertTo-Json -Depth 1";

            string convertOutput(string jsonOutput)
            {
                StorageInfoModel? storageInfo = JsonSerializer.Deserialize<StorageInfoModel>(jsonOutput);
                storageInfo.IpAddress = param.Ip;
                storageInfo.Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                return JsonSerializer.Serialize(storageInfo);
            }

            return await base.ExecCommand<string>(param, command, convertOutput);
        }
    }
}
