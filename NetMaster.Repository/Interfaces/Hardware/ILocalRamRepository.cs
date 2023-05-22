// NetMaster.Repository/Interfaces/ILocalRamRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;

namespace NetMaster.Repository.Interfaces.Hardware
{
    [AutoDI]
    public interface ILocalRamRepository : ILocalHardwareRepository<RamInfoDataModel>
    {
        new Task<RepositoryResultModel<RamInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}