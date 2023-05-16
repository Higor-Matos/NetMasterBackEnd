using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure;
using NetMaster.Repository.Implementation.MongoDB;

namespace NetMaster.Repository.Implementation.System
{
    public class InstalledProgramsRepository : BaseMongoRepository<InstalledProgramsResponseModel>
    {
        public InstalledProgramsRepository(MongoDbContext dbContext) : base(dbContext, "ProgramsInfo")
        {
        }
    }
}
