// NetMaster.Repository/Local/Hardware/LocalRamRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Implementation.Powershell;
using NetMaster.Repository.Implementations.Powershell;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Repository.Implementation.Hardware
{
    public class LocalRamRepository : BasePowershellRepository, ILocalRamRepository
    {
        public async Task<RepositoryResultModel<RamInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-WmiObject -Class Win32_OperatingSystem | " +
                             "Select-Object -Property @{Name='FreePhysicalMemory_GB';Expression={[math]::Round($_.FreePhysicalMemory / 1MB, 2)}}, " +
                             "@{Name='TotalVisibleMemorySize_GB';Expression={[math]::Round($_.TotalVisibleMemorySize / 1MB, 2)}}, " +
                             "@{Name='PSComputerName';Expression={$env:COMPUTERNAME}} | ConvertTo-Json -Depth 1";

            return await ExecCommand(param, command, jsonOutput => ConvertOutput<RamInfoDataModel>(jsonOutput, param.Ip));
        }
    }
}
