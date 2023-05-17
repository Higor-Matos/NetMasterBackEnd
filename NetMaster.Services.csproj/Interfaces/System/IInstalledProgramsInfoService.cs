// NetMaster.Services/Interfaces/System/IInstalledProgramsInfoService.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.System
{
    [AutoDI]
    public interface IInstalledProgramsInfoService : ISystemInfoService<InstalledProgramsResponseModel>
    {
        Task<ServiceResultModel<InstalledProgramsResponseModel>> SaveLocalInstalledProgramsInfoAsync(string ip);
        Task<ServiceResultModel<InstalledProgramsResponseModel>> GetInstalledProgramsByComputerNameAsync(string computerName);
    }
}