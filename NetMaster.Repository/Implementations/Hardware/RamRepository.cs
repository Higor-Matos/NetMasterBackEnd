// NetMaster.Repository/Local/Hardware/RamRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure.Context;
using NetMaster.Repository.Implementations.MongoDB;
using NetMaster.Repository.Interfaces.Hardware;

namespace NetMaster.Repository.Implementation.Hardware
{
    public class RamRepository : BaseMongoRepository<RamInfoDataModel>, IRamRepository
    {
        public RamRepository(MongoDbContext dbContext) : base(dbContext, "RamInfo")
        {
        }
    }
}
