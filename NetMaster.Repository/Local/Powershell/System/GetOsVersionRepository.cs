using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using Newtonsoft.Json;

namespace NetMaster.Repository.Local.Powershell.System
{
    public class GetOsVersionRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel<OSVersionInfoModel>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-CimInstance -ClassName Win32_OperatingSystem | " +
                             "Select-Object Caption, Version, @{Name='PSComputerName';Expression={$env:COMPUTERNAME}} | ConvertTo-Json -Depth 1";

            OSVersionInfoModel convertOutput(string jsonOutput)
            {
                OSVersionInfoModel? osVersionInfo = JsonConvert.DeserializeObject<OSVersionInfoModel>(jsonOutput);
                osVersionInfo.IpAddress = param.Ip;
                osVersionInfo.Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                return osVersionInfo;
            }

            return await base.ExecCommand(param, command, convertOutput);
        }
    }
}
