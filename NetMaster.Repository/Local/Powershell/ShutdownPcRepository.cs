using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell
{
    public class ShutdownPcRepository : BasePowershellRepository
    {
        private static readonly string command = "Stop-Computer -force";
        private static readonly string args = "";

        public override async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await RunCommand(param, command, args);
        }
    }
}