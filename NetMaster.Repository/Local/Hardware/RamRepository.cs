using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;

namespace NetMaster.Repository.Local.Hardware
{
    public class RamRepository : BaseRepository<RamInfoDataModel>
    {
        public RamRepository(MongoDbContext dbContext) : base(dbContext, "RamInfo")
        {
        }
    }
}