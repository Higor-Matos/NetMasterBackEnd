using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;
using NetMaster.Repository.Implementation.MongoDB;

namespace NetMaster.Repository.Implementation.System
{
    public class UsersRepository : BaseMongoRepository<UsersInfoDataModel>
    {
        public UsersRepository(MongoDbContext dbContext) : base(dbContext, "UserInfo")
        {
        }
    }

}
