using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace NetMaster.Repository.Local.Powershell.System
{
    public class GetOsVersionRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel<OSVersionInfo>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-CimInstance -ClassName Win32_OperatingSystem | " +
                             "Select-Object Caption, Version, @{Name='PSComputerName';Expression={$env:COMPUTERNAME}} | ConvertTo-Json -Depth 1";

            Func<string, OSVersionInfo> convertOutput = (jsonOutput) =>
            {
                var osVersionInfo = JsonConvert.DeserializeObject<OSVersionInfo>(jsonOutput);
                osVersionInfo.IpAddress = param.Ip;
                osVersionInfo.Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                return osVersionInfo;
            };

            return await base.ExecCommand(param, command, convertOutput);
        }
    }
}
