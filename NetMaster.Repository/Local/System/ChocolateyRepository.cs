using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;

namespace NetMaster.Repository.Local.System
{
    public class ChocolateyRepository : BaseMongoRepository<ChocolateyInfoDataModel>
    {
        public ChocolateyRepository(MongoDbContext dbContext) : base(dbContext, "ChocolateyInfo")
        {
        }
    }
}
