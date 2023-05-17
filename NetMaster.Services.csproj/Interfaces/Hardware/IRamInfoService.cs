// NetMaster.Services.Interfaces/Hardware/IRamInfoService.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.Hardware
{
    [AutoDI]
    public interface IRamInfoService : IHardwareInfoService<RamInfoDataModel>
    {
        Task<ServiceResultModel<RamInfoDataModel>> SaveLocalRamInfoAsync(string ip);
        Task<ServiceResultModel<RamInfoDataModel>> GetRamInfoByComputerNameAsync(string computerName);
    }
}
