// NetMaster.Repository/Interfaces/IInstalledProgramsRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface IInstalledProgramsRepository : ISystemRepository<InstalledProgramsResponseModel>
    {
    }
}