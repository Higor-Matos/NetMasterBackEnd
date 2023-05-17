// NetMaster.Services/Interfaces/System/ISystemInfoService.cs
using NetMaster.Common;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.System
{
    [AutoDI]
    public interface ISystemInfoService<T> where T : class
    {
        Task<ServiceResultModel<T>> SaveLocalSystemInfoAsync(string ip);
        Task<ServiceResultModel<T>> GetSystemInfoByComputerNameAsync(string computerName);
    }
}