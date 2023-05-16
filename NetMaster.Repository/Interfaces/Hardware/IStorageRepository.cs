// NetMaster.Repository/Interfaces/IStorageRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.Hardware
{
    public interface IStorageRepository : IHardwareRepository<StorageInfoDataModel>
    {
    }
}
