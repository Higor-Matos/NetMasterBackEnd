// NetMaster.Services/Interfaces/System/IUsersInfoService.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.System
{
    [AutoDI]
    public interface IUsersInfoService : ISystemInfoService<UsersInfoDataModel>
    {
        Task<ServiceResultModel<UsersInfoDataModel>> SaveLocalUsersInfoAsync(string ip);
        Task<ServiceResultModel<UsersInfoDataModel>> GetUsersInfoByComputerNameAsync(string computerName);
    }
}