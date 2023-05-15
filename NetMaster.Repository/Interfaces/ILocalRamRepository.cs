// NetMaster.Repository/Interfaces/ILocalRamRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Domain.Models;

namespace NetMaster.Repository.Interfaces
{
    public interface ILocalRamRepository : IBasePowershellRepository
    {
        Task<RepositoryResultModel<RamInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
