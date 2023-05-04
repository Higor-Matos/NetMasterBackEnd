using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell.Hardware
{
    public class StorageRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel<StorageInfoModel>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-CimInstance -ClassName Win32_LogicalDisk | Select-Object -Property DeviceID,@{Name='Size_GB';Expression={[math]::Round(($_.Size / 1GB), 2)}},@{Name='FreeSpace_GB';Expression={[math]::Round(($_.FreeSpace / 1GB), 2)}},@{Name='PSComputerName';Expression={$env:COMPUTERNAME}} | ConvertTo-Json -Depth 1";

            return await base.ExecCommand<StorageInfoModel>(param, command, jsonOutput => ConvertOutput<StorageInfoModel>(jsonOutput, param.Ip));
        }
    }
}