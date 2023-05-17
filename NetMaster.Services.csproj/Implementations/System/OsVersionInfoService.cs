// NetMaster.Services/Implementation/System/OsVersionInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.System;
using NetMaster.Services.Implementations.System;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.System;
using System.Threading.Tasks;

namespace NetMaster.Services.Implementation.System
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