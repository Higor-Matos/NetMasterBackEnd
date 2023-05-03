using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell.Hardware
{
    public class GetRamRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel<RamInfo>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-WmiObject -Class Win32_OperatingSystem | " +
                             "Select-Object -Property @{Name='FreePhysicalMemory_GB';Expression={[math]::Round($_.FreePhysicalMemory / 1MB, 2)}}, " +
                             "@{Name='TotalVisibleMemorySize_GB';Expression={[math]::Round($_.TotalVisibleMemorySize / 1MB, 2)}}, " +
                             "@{Name='PSComputerName';Expression={$env:COMPUTERNAME}} | ConvertTo-Json -Depth 1";

            Func<string, RamInfo> convertOutput = (jsonOutput) =>
            {
                var ramInfo = JsonConvert.DeserializeObject<RamInfo>(jsonOutput);
                ramInfo.IpAddress = param.Ip;
                ramInfo.Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                return ramInfo;
            };

            return await base.ExecCommand(param, command, convertOutput);
        }
    }
}
