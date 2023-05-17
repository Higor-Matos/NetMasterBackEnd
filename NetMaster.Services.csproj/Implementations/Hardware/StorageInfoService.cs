// NetMaster.Services/Implementations/Hardware/StorageInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.Hardware;
using NetMaster.Repository.Interfaces.System;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.Hardware;

namespace NetMaster.Services.Implementations.Hardware
{
    public class StorageInfoService : HardwareInfoService<StorageInfoDataModel>, IStorageInfoService
    {
        public StorageInfoService(
            IStorageRepository storageRepository,
            ILocalStorageRepository localStorageRepository,
            ICommandRunner commandRunner,
            IResultConverter resultConverter
        ) : base(storageRepository, localStorageRepository, commandRunner, resultConverter)
        {
        }

        public Task<ServiceResultModel<StorageInfoDataModel>> SaveLocalStorageInfoAsync(string ip)
        {
            return SaveLocalHardwareInfoAsync(ip);
        }

        public Task<ServiceResultModel<StorageInfoDataModel>> GetStorageInfoByComputerNameAsync(string computerName)
        {
            return GetHardwareInfoByComputerNameAsync(computerName);
        }
    }
}
