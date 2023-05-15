using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;

namespace NetMaster.Repository.Local.System
{
    public class OsVersionRepository : BaseMongoRepository<OSVersionInfoDataModel>
    {
        public OsVersionRepository(MongoDbContext dbContext) : base(dbContext, "OsVersionInfo")
        {
        }
    }
}
