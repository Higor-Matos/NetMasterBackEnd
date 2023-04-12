using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell
{
    public class VerifyChocolateyRepository : BasePowershellRepository
    {
        private static readonly string command = "choco -v";
        private static readonly string args = "";

        public async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await base.ExecCommand(param, command, args);
        }
    }
}
