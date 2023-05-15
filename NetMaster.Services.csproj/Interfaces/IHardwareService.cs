// NetMaster.Services/Interfaces/IHardwareService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces
{
    public interface IHardwareService
    {
        Task<ServiceResultModel<RamInfoDataModel>> GetRamInfoAsync(string computerName);
        Task<ServiceResultModel<StorageInfoDataModel>> GetStorageInfoAsync(string computerName);
    }
}
