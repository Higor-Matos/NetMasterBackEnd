// NetMaster.Repository/Interfaces/IRamRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;

namespace NetMaster.Repository.Interfaces.Hardware
{
    [AutoDI]
    public interface IRamRepository : IHardwareRepository<RamInfoDataModel>
    {
    }
}