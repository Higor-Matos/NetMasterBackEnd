// NetMaster.Repository/Local/Hardware/StorageRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;
using NetMaster.Repository.Interfaces.Hardware;

namespace NetMaster.Repository.Local.Hardware
{
    public class StorageRepository : BaseMongoRepository<StorageInfoDataModel>, IStorageRepository, IHardwareRepository<StorageInfoDataModel>
    {
        public StorageRepository(MongoDbContext dbContext) : base(dbContext, "StorageInfo")
        {
        }
    }
}