using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell.Software.Installers
{
    public class InstallVlcRepository : BasePowershellRepository
    {
        private static readonly string command = "choco install vlc -y --force";
        private static readonly string parameters = "";

        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand<string>(param, command, jsonOutput => jsonOutput, parameters);
        }
    }
}