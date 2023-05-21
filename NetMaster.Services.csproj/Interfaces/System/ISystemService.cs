// NetMaster.Services.Interfaces/System/ISystemService.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Service;

namespace NetMaster.Services.Interfaces.System
{
    [AutoDI]
    public interface ISystemService
    {
        Task<ServiceResultModel<ChocolateyInfoDataModel>> GetChocolateyInfoAsync(string computerName);
        Task<ServiceResultModel<InstalledProgramsResponseModel>> GetInstalledProgramsInfoAsync(string computerName);
        Task<ServiceResultModel<OSVersionInfoDataModel>> GetOsVersionInfoAsync(string computerName);
        Task<ServiceResultModel<UsersInfoDataModel>> GetUsersInfoAsync(string computerName);
    }
}