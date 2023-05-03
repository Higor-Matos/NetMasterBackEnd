using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell.System
{
    public class ShutdownPcRepository : BasePowershellRepository
    {
        private static readonly string command = "Stop-Computer -force";

        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand<string>(param, command, jsonOutput => jsonOutput);
        }
    }
}
