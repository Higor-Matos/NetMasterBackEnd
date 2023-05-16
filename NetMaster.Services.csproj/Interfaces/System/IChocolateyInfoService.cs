// NetMaster.Services/Interfaces/System/IChocolateyInfoService.cs

using NetMaster.Domain.Models.DataModels;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Services.Interfaces.System
{
    public interface IChocolateyInfoService : ISystemInfoService<ChocolateyInfoDataModel>
    {
    }
}
