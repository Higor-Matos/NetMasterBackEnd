// NetMaster.Repository/Interfaces/ILocalRamRepository.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.Hardware
{
    public interface ILocalRamRepository : ILocalHardwareRepository<RamInfoDataModel>
    {
        Task<RepositoryResultModel<RamInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}