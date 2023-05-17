// NetMaster.Repository/Local/Hardware/StorageRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure.Context;
using NetMaster.Repository.Implementations.MongoDB;
using NetMaster.Repository.Interfaces.Hardware;

namespace NetMaster.Repository.Implementation.Hardware
{
    public class StorageRepository : BaseMongoRepository<StorageInfoDataModel>, IStorageRepository
    {
        public StorageRepository(MongoDbContext dbContext) : base(dbContext, "StorageInfo")
        {
        }
    }
}