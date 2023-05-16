// NetMaster.Services/Interfaces/system/ISystemInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.System
{
    public interface ISystemInfoService<T> where T : BaseInfoDataModel
    {
        Task SaveLocalSystemInfoAsync(string ip);
        Task<ServiceResultModel<T>> GetSystemInfo(string ip);
    }
}