// NetMaster.Repository/Implementation/System/InstalledProgramsRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Infrastructure.Context;
using NetMaster.Repository.Implementations.MongoDB;
using NetMaster.Repository.Interfaces.Software;

namespace NetMaster.Repository.Implementation.System
{
    public class InstalledProgramsRepository : BaseMongoRepository<InstalledProgramsResponseModel>, IInstalledProgramsRepository
    {
        public InstalledProgramsRepository(MongoDbContext dbContext) : base(dbContext, "ProgramsInfo")
        {
        }
    }
}