using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell.Software.Installers
{
    public class InstallWinrarRepository : BasePowershellRepository
    {
        private static readonly string command = "choco install winrar -y --force";
        private static readonly string args = "";

        public async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand(param, command, args);
        }
    }
}