// NetMaster.Services/Interfaces/System/IOsVersionInfoService.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Service;

namespace NetMaster.Services.Interfaces.System
{
    [AutoDI]
    public interface IOsVersionInfoService : ISystemInfoService<OSVersionInfoDataModel>
    {
        Task<ServiceResultModel<OSVersionInfoDataModel>> SaveLocalOsVersionInfoAsync(string ip);
        Task<ServiceResultModel<OSVersionInfoDataModel>> GetOsVersionInfoByComputerNameAsync(string computerName);
    }
}