// NetMaster.Repository/Implementation/System/LocalOsVersionRepository.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Implementation.Powershell;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Repository.Implementation.System
{
    public class LocalOsVersionRepository : BasePowershellRepository, ILocalOsVersionRepository
    {
        public async Task<RepositoryResultModel<OSVersionInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "Get-CimInstance -ClassName Win32_OperatingSystem | " +
                             "Select-Object Caption, Version, @{Name='PSComputerName';Expression={$env:COMPUTERNAME}} | ConvertTo-Json -Depth 1";

            return await ExecCommand(param, command, jsonOutput => ConvertOutput<OSVersionInfoDataModel>(jsonOutput, param.Ip));
        }
    }
}
