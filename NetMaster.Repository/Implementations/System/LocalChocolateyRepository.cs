using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Implementations.Powershell;
using NetMaster.Repository.Interfaces.System;
using Newtonsoft.Json;

namespace NetMaster.Repository.Implementations.System
{
    public class LocalChocolateyRepository : BasePowershellRepository, ILocalChocolateyRepository
    {
        public async Task<RepositoryResultModel<ChocolateyInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "choco -v | Select-Object @{Name='ChocolateyVersion';Expression={$_}}, @{Name='PSComputerName';Expression={$env:COMPUTERNAME}} | ConvertTo-Json -Depth 1";

            return await ExecCommand<ChocolateyInfoDataModel>(param, command, jsonOutput => ConvertOutput<ChocolateyInfoDataModel>(jsonOutput, param.Ip));
        }
    }
}
