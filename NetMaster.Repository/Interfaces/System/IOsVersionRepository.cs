// NetMaster.Repository/Interfaces/IOsVersionRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface IOsVersionRepository : ISystemRepository<OSVersionInfoDataModel>
    {
    }
}