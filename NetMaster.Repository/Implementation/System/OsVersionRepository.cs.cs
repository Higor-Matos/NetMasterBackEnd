using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;
using NetMaster.Repository.Implementation.MongoDB;

namespace NetMaster.Repository.Implementation.System
{
    public class OsVersionRepository : BaseMongoRepository<OSVersionInfoDataModel>
    {
        public OsVersionRepository(MongoDbContext dbContext) : base(dbContext, "OsVersionInfo")
        {
        }
    }
}
