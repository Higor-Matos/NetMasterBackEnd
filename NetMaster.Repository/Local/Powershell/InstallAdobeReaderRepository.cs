using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell
{
    public class InstallAdobeReaderRepository : BasePowershellRepository
    {
        private static readonly string command = "choco install adobereader";
        private static readonly string args = "-y";

        public override async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await RunCommand(param, command, args);
        }
    }
}