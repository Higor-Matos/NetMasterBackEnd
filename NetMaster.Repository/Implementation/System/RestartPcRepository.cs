using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Implementation.Powershell;

namespace NetMaster.Repository.Implementation.System
{
    public class RestartPcRepository : BasePowershellRepository
    {
        private static readonly string command = "Restart-Computer -force";

        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand(param, command, jsonOutput => jsonOutput);
        }
    }
}
