// NetMaster.Repository/Interfaces/IStorageRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces
{
    public interface IStorageRepository : IHardwareRepository<StorageInfoDataModel>
    {
    }
}
