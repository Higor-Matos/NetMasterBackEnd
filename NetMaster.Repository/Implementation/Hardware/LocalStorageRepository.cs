// NetMaster.Repository/Local/Hardware/LocalStorageRepository.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Implementation.Powershell;
using NetMaster.Repository.Interfaces.Hardware;

namespace NetMaster.Repository.Implementation.Hardware
{
    public class LocalStorageRepository : BasePowershellRepository, ILocalStorageRepository, ILocalHardwareRepository<StorageInfoDataModel>
    {
        public async Task<RepositoryResultModel<StorageInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-CimInstance -ClassName Win32_LogicalDisk | Select-Object -Property DeviceID,@{Name='Size_GB';Expression={[math]::Round(($_.Size / 1GB), 2)}},@{Name='FreeSpace_GB';Expression={[math]::Round(($_.FreeSpace / 1GB), 2)}},@{Name='PSComputerName';Expression={$env:COMPUTERNAME}} | ConvertTo-Json -Depth 1";

            return await ExecCommand(param, command, jsonOutput => ConvertOutput<StorageInfoDataModel>(jsonOutput, param.Ip));
        }

        public async Task<RepositoryResultModel<StorageInfoDataModel>> ExecCommand(string ip)
        {
            RepositoryPowerShellParamModel param = new(ip);
            return await ExecCommand(param);
        }
    }
}
