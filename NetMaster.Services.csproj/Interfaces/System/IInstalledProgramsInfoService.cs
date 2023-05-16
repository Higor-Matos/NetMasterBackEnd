// NetMaster.Services/Interfaces/System/IInstalledProgramsInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Services.Interfaces.System
{
    public interface IInstalledProgramsInfoService : ISystemInfoService<InstalledProgramsResponseModel>
    {
    }
}
