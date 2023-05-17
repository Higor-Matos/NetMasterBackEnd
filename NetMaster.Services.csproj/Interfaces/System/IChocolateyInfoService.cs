// NetMaster.Services/Interfaces/System/IChocolateyInfoService.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.System
{
    [AutoDI]
    public interface IChocolateyInfoService : ISystemInfoService<ChocolateyInfoDataModel>
    {
        Task<ServiceResultModel<ChocolateyInfoDataModel>> SaveLocalChocolateyInfoAsync(string ip);
        Task<ServiceResultModel<ChocolateyInfoDataModel>> GetChocolateyInfoByComputerNameAsync(string computerName);
    }
}