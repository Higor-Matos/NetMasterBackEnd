// NetMaster.Repository/Interfaces/IInstalledProgramsRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Repository.Interfaces.Software
{
    [AutoDI]
    public interface IInstalledProgramsRepository : ISystemRepository<InstalledProgramsResponseModel>
    {
    }
}