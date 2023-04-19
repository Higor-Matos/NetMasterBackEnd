using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell.Software.Installers
{
    public class InstallVlcRepository : BasePowershellRepository
    {
        private static readonly string command = "choco install vlc -y --force";
        private static readonly string args = "";

        public async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand(param, command, args);
        }
    }
}