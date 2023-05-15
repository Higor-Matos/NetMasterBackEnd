// NetMaster.Services/Interfaces/IStorageInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces
{
    public interface IStorageInfoService : IHardwareInfoService<StorageInfoDataModel>
    {
        Task<ServiceResultModel<StorageInfoDataModel>> SaveLocalStorageInfoAsync(string ip);
        Task<ServiceResultModel<StorageInfoDataModel>> GetStorageInfoByComputerNameAsync(string computerName);
    }
}
