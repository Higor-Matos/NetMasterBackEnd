// NetMaster.Repository/Implementation/System/UsersRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure.Context;
using NetMaster.Repository.Implementations.MongoDB;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Repository.Implementation.System
{
    public class UsersRepository : BaseMongoRepository<UsersInfoDataModel>, IUsersRepository
    {
        public UsersRepository(MongoDbContext dbContext) : base(dbContext, "UserInfo")
        {
        }
    }
}
