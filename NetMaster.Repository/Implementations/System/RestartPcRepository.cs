using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Implementation.Powershell;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Repository.Implementation.System
{
    public class RestartPcRepository : BasePowershellRepository, IRestartPcRepository
    {
        private static readonly string command = "Restart-Computer -force";

        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand(param, command, jsonOutput => jsonOutput);
        }
    }
}
