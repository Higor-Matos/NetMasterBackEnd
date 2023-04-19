using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;


namespace NetMaster.Repository.Local.Powershell.Software
{
    public class GetInstalledProgramsRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "choco list --local-only | Select-Object -Skip 1 | Where-Object { $_ -notmatch '^\\d+ packages installed' } | Where-Object { $_ -notmatch '^KB\\d+' }";
            string parameters = "";
            return await base.ExecCommand(param, command, parameters);
        }
    }
}
