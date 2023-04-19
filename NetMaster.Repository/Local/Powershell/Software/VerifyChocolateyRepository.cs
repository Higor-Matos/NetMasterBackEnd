using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell.Software
{
    public class VerifyChocolateyRepository : BasePowershellRepository
    {
        private static readonly string command = "choco -v";
        private static readonly string args = "";

        public async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand(param, command, args);
        }
    }
}
