using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell.Software.Installers
{
    public class InstallOffice365Repository : BasePowershellRepository
    {
        private static readonly string command = "choco install office365business -y --force";

        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand<string>(param, command, jsonOutput => jsonOutput);
        }
    }
}