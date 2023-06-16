// NetMaster.Repository/Implementation/System/OsVersionRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure.Context;
using NetMaster.Repository.Implementations.MongoDB;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Repository.Implementations.System
{
    public class OsVersionRepository : BaseMongoRepository<OSVersionInfoDataModel>, IOsVersionRepository
    {
        public OsVersionRepository(MongoDbContext dbContext) : base(dbContext, "OsVersionInfo")
        {
        }
    }
}