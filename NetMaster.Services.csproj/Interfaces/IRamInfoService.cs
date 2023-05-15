// NetMaster.Services/Interfaces/IRamInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces
{
    public interface IRamInfoService
    {
        Task<ServiceResultModel<RamInfoDataModel>> SaveLocalRamInfoAsync(string ip);
        Task<ServiceResultModel<RamInfoDataModel>> GetRamInfoByComputerNameAsync(string computerName);
    }
}
