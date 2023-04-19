using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace NetMaster.Repository.Local.Powershell.Hardware
{
    public class GetRamRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-WmiObject -Class Win32_OperatingSystem | Select-Object -Property FreePhysicalMemory,TotalVisibleMemorySize";
            string parameters = "";
            return await base.ExecCommand(param, command, parameters);
        }
    }
}
