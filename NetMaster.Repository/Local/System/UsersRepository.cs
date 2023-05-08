using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;

namespace NetMaster.Repository.Local.System
{
    public class UsersRepository : BaseRepository<UsersInfoDataModel>
    {
        public UsersRepository(MongoDbContext dbContext) : base(dbContext, "UserInfo")
        {
        }
    }

}
