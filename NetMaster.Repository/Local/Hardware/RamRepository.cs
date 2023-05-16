// NetMaster.Repository/Local/Hardware/RamRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Infrastructure;
using System.Threading.Tasks;
using System.Collections.Generic;
using NetMaster.Repository.Interfaces.Hardware;

namespace NetMaster.Repository.Local.Hardware
{
    public class RamRepository : BaseMongoRepository<RamInfoDataModel>, IRamRepository, IHardwareRepository<RamInfoDataModel>
    {
        public RamRepository(MongoDbContext dbContext) : base(dbContext, "RamInfo")
        {
        }
    }
}
