using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell.System
{
    public class GetOsVersionRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-CimInstance -ClassName Win32_OperatingSystem | Select-Object Caption, Version";
            string parameters = "";
            return await ExecCommand(param, command, parameters);
        }
    }
}
