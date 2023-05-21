using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Implementation.Powershell;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Repository.Implementation.System
{
    public class ShutdownPcRepository : BasePowershellRepository, IShutdownPcRepository
    {
        private static readonly string command = "Stop-Computer -force";

        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await ExecCommand(param, command, jsonOutput => jsonOutput);
        }
    }
}
