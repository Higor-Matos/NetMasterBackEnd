using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;

namespace NetMaster.Repository.Local.Hardware
{
    public class StorageRepository : BaseRepository<StorageInfoDataModel>
    {
        public StorageRepository(MongoDbContext dbContext) : base(dbContext, "StorageInfo")
        {
        }
    }
}





