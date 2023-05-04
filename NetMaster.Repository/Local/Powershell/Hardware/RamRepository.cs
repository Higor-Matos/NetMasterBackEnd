using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using Newtonsoft.Json;

namespace NetMaster.Repository.Local.Powershell.Hardware
{
    public class RamRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel<RamInfoModel>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-WmiObject -Class Win32_OperatingSystem | " +
                             "Select-Object -Property @{Name='FreePhysicalMemory_GB';Expression={[math]::Round($_.FreePhysicalMemory / 1MB, 2)}}, " +
                             "@{Name='TotalVisibleMemorySize_GB';Expression={[math]::Round($_.TotalVisibleMemorySize / 1MB, 2)}}, " +
                             "@{Name='PSComputerName';Expression={$env:COMPUTERNAME}} | ConvertTo-Json -Depth 1";

            return await base.ExecCommand<RamInfoModel>(param, command, jsonOutput => ConvertOutput<RamInfoModel>(jsonOutput, param.Ip));
        }
    }
}
