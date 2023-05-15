using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;

namespace NetMaster.Repository.Local.System
{
    public class UsersRepository : BaseMongoRepository<UsersInfoDataModel>
    {
        public UsersRepository(MongoDbContext dbContext) : base(dbContext, "UserInfo")
        {
        }
    }

}
