// NetMaster.Services/Interfaces/IRamInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Services.Hardware;

namespace NetMaster.Services.Interfaces
{
    public interface IRamInfoService : IHardwareInfoService<RamInfoDataModel>
    {
        Task<ServiceResultModel<RamInfoDataModel>> SaveLocalRamInfoAsync(string ip);
        Task<ServiceResultModel<RamInfoDataModel>> GetRamInfoByComputerNameAsync(string computerName);
    }
}
