using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using System.Text.Json;

namespace NetMaster.Repository.Local.Powershell.System
{
    public class OsVersionRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel<OSVersionInfoModel>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-CimInstance -ClassName Win32_OperatingSystem | " +
                             "Select-Object Caption, Version, @{Name='PSComputerName';Expression={$env:COMPUTERNAME}} | ConvertTo-Json -Depth 1";

            return await base.ExecCommand(param, command, jsonOutput => ConvertOutput<OSVersionInfoModel>(jsonOutput, param.Ip));
        }
    }
}
