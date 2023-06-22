// NetMaster.Repository/Local/System/ChocolateyRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure.Context;
using NetMaster.Repository.Implementations.MongoDB;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Repository.Implementation.System
{
    public class ChocolateyRepository : BaseMongoRepository<ChocolateyInfoDataModel>, IChocolateyRepository
    {
        public ChocolateyRepository(MongoDbContext dbContext) : base(dbContext, "ChocolateyInfo")
        {
        }
    }
}