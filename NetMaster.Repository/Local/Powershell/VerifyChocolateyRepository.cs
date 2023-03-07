using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell
{
    public class VerifyChocolateyRepository : BasePowershellRepository
    {
        private static readonly string command = "choco";
        private static readonly string args = "-v";

        public override async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await RunCommand(param, command, args);
        }
    }
}