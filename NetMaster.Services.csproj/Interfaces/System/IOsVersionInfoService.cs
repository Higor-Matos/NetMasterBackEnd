// NetMaster.Services/Interfaces/System/IOsVersionInfoService.cs

using NetMaster.Domain.Models.DataModels;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Services.Interfaces.System
{
    public interface IOsVersionInfoService : ISystemInfoService<OSVersionInfoDataModel>
    {
    }
}
