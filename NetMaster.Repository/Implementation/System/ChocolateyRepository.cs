using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;
using NetMaster.Repository.Implementation.MongoDB;

namespace NetMaster.Repository.Implementation.System
{
    public class ChocolateyRepository : BaseMongoRepository<ChocolateyInfoDataModel>
    {
        public ChocolateyRepository(MongoDbContext dbContext) : base(dbContext, "ChocolateyInfo")
        {
        }
    }
}
