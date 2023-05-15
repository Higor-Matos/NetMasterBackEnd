// NetMaster.Services.Interfaces/Hardware/IStorageInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.Hardware
{
    public interface IStorageInfoService : IHardwareInfoService<StorageInfoDataModel>
    {
        Task<ServiceResultModel<StorageInfoDataModel>> SaveLocalStorageInfoAsync(string ip);
        Task<ServiceResultModel<StorageInfoDataModel>> GetStorageInfoByComputerNameAsync(string computerName);
    }
}
