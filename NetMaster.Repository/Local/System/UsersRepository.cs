using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure.DataBase;

namespace NetMaster.Repository.Local.System
{
    public class UsersRepository : BaseRepository<UsersInfoDataModel>
    {
        public UsersRepository(MongoDbContext dbContext) : base(dbContext, "UserInfo")
        {
        }
    }

}
