using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Implementation.Powershell;
using NetMaster.Repository.Interfaces.Software;

namespace NetMaster.Repository.Implementation.Software
{
    public class InstallGoogleChromeRepository : BasePowershellRepository, IInstallGoogleChromeRepository
    {
        private static readonly string command = "choco install googlechrome -y --force";

        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand(param, command, jsonOutput => jsonOutput);
        }
    }
}