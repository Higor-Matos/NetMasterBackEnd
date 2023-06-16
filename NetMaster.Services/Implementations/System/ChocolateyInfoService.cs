// NetMaster.Services/Implementation/System/ChocolateyInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Repository.Interfaces.System;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.System;

namespace NetMaster.Services.Implementations.System
{
    public class ChocolateyInfoService : SystemInfoService<ChocolateyInfoDataModel>, IChocolateyInfoService
    {
        public ChocolateyInfoService(
            ISystemRepository<ChocolateyInfoDataModel> chocolateyRepository,
            ILocalSystemRepository<ChocolateyInfoDataModel> localChocolateyRepository,
            ICommandRunner commandRunner,
            IResultConverter resultConverter
        ) : base(chocolateyRepository, localChocolateyRepository, commandRunner, resultConverter)
        {
        }

        public Task<ServiceResultModel<ChocolateyInfoDataModel>> SaveLocalChocolateyInfoAsync(string ip)
        {
            return SaveLocalSystemInfoAsync(ip);
        }

        public Task<ServiceResultModel<ChocolateyInfoDataModel>> GetChocolateyInfoByComputerNameAsync(string computerName)
        {
            return GetSystemInfoByComputerNameAsync(computerName);
        }
    }
}