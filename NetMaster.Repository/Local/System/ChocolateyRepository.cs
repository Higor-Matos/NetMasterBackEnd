// NetMaster.Repository/Local/Hardware/ChocolateyRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure.DataBase;

namespace NetMaster.Repository.Local.System
{
    public class ChocolateyRepository : BaseRepository<ChocolateyInfoDataModel>
    {
        public ChocolateyRepository(MongoDbContext dbContext) : base(dbContext, "ChocolateyInfo")
        {
        }
    }
}
