using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell.Software.Installers
{
    public class InstallGoogleChromeRepository : BasePowershellRepository
    {
        private static readonly string command = "choco install googlechrome -y --force";

        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand<string>(param, command, jsonOutput => jsonOutput);
        }
    }
}