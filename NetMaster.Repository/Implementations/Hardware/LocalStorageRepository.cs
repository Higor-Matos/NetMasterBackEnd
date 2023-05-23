// NetMaster.Repository/Local/Hardware/LocalStorageRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Implementations.Powershell;
using NetMaster.Repository.Interfaces.Hardware;

namespace NetMaster.Repository.Implementations.Hardware
{
    public class LocalStorageRepository : BasePowershellRepository, ILocalStorageRepository
    {
        public async Task<RepositoryResultModel<StorageInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "$Disks = Get-CimInstance -ClassName Win32_LogicalDisk | Select-Object -Property DeviceID,@{Name='Size_GB';Expression={[math]::Round(($_.Size / 1GB), 2)}},@{Name='FreeSpace_GB';Expression={[math]::Round(($_.FreeSpace / 1GB), 2)}}; $Result = [PSCustomObject]@{PSComputerName = $env:COMPUTERNAME; Disks = $Disks;}; $Result | ConvertTo-Json -Depth 2\r\n";

            return await ExecCommand(param, command, jsonOutput => ConvertOutput<StorageInfoDataModel>(jsonOutput, param.Ip));
        }
    }
}
