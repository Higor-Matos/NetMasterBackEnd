// NetMaster.Services.Interfaces/Hardware/IHardwareInfoService.cs
using NetMaster.Common;
using NetMaster.Domain.Models.Results.Service;

namespace NetMaster.Services.Interfaces.Hardware
{
    [AutoDI]
    public interface IHardwareInfoService<T> where T : class
    {
        Task<ServiceResultModel<T>> SaveLocalHardwareInfoAsync(string ip);
        Task<ServiceResultModel<T>> GetHardwareInfoByComputerNameAsync(string computerName);
    }
}
