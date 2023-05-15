// NetMaster.Services/Hardware/StorageInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces;
using NetMaster.Services.Interfaces;
using System.Threading.Tasks;

namespace NetMaster.Services.Hardware
{
    public class StorageInfoService : HardwareInfoService<StorageInfoDataModel>, IStorageInfoService
    {
        public StorageInfoService(IStorageRepository storageRepository, ILocalStorageRepository localStorageRepository)
            : base(storageRepository, localStorageRepository) { }

        public async Task<ServiceResultModel<StorageInfoDataModel>> SaveLocalStorageInfoAsync(string ip)
        {
            return await SaveLocalHardwareInfoAsync(ip);
        }

        public async Task<ServiceResultModel<StorageInfoDataModel>> GetStorageInfoByComputerNameAsync(string computerName)
        {
            return await GetHardwareInfoByComputerNameAsync(computerName);
        }
    }
}
