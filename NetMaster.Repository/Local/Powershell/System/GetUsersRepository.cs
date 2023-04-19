using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace NetMaster.Repository.Local.Powershell.System
{
    public class GetUsersRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-LocalUser | Where-Object {$_.Enabled -eq 'True'} | Select-Object Name";

            string parameters = "";
            return await base.ExecCommand(param, command, parameters);
        }
    }
}
