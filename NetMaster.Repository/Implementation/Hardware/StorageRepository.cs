// NetMaster.Repository/Local/Hardware/StorageRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;
using NetMaster.Repository.Implementation.MongoDB;
using NetMaster.Repository.Interfaces.Hardware;

namespace NetMaster.Repository.Implementation.Hardware
{
    public class StorageRepository : BaseMongoRepository<StorageInfoDataModel>, IStorageRepository, IHardwareRepository<StorageInfoDataModel>
    {
        public StorageRepository(MongoDbContext dbContext) : base(dbContext, "StorageInfo")
        {
        }
    }
}