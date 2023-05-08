using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;

namespace NetMaster.Repository.Local.System
{
    public class OsVersionRepository : BaseRepository<OSVersionInfoDataModel>
    {
        public OsVersionRepository(MongoDbContext dbContext) : base(dbContext, "OsVersionInfo")
        {
        }
    }
}
