// NetMaster.Services.Interfaces/Hardware/IStorageInfoService.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Service;

namespace NetMaster.Services.Interfaces.Hardware
{
    [AutoDI]
    public interface IStorageInfoService : IHardwareInfoService<StorageInfoDataModel>
    {
        Task<ServiceResultModel<StorageInfoDataModel>> SaveLocalStorageInfoAsync(string ip);
        Task<ServiceResultModel<StorageInfoDataModel>> GetStorageInfoByComputerNameAsync(string computerName);
    }
}
