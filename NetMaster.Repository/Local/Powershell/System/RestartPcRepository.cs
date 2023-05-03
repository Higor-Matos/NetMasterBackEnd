using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Local.Powershell.System
{
    public class RestartPcRepository : BasePowershellRepository
    {
        private static readonly string command = "Restart-Computer -force";

        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand<string>(param, command, jsonOutput => jsonOutput);
        }
    }
}
