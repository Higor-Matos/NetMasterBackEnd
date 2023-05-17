// NetMaster.Repository/Interfaces/IStorageRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.Hardware
{
    [AutoDI]
    public interface IStorageRepository : IHardwareRepository<StorageInfoDataModel>
    {
    }
}
