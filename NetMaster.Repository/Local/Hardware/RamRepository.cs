// NetMaster.Repository/Local/Hardware/RamRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure.DataBase;

namespace NetMaster.Repository.Local.Hardware
{
    public class RamRepository : BaseRepository<RamInfoDataModel>
    {
        public RamRepository(MongoDbContext dbContext) : base(dbContext, "RamInfo")
        {
        }
    }
}