// NetMaster.Services/Implementation/System/OsVersionInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Repository.Interfaces.System;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.System;

namespace NetMaster.Services.Implementations.System
{
    public class OsVersionInfoService : SystemInfoService<OSVersionInfoDataModel>, IOsVersionInfoService
    {
        public OsVersionInfoService(
            ISystemRepository<OSVersionInfoDataModel> osVersionRepository,
            ILocalSystemRepository<OSVersionInfoDataModel> localOsVersionRepository,
            ICommandRunner commandRunner,
            IResultConverter resultConverter
        ) : base(osVersionRepository, localOsVersionRepository, commandRunner, resultConverter)
        {
        }

        public Task<ServiceResultModel<OSVersionInfoDataModel>> SaveLocalOsVersionInfoAsync(string ip)
        {
            return SaveLocalSystemInfoAsync(ip);
        }

        public Task<ServiceResultModel<OSVersionInfoDataModel>> GetOsVersionInfoByComputerNameAsync(string computerName)
        {
            return GetSystemInfoByComputerNameAsync(computerName);
        }
    }
}