// NetMaster.Repository/Interfaces/ILocalRamRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.Hardware;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface ILocalRamRepository : ILocalHardwareRepository<RamInfoDataModel>
    {
        Task<RepositoryResultModel<RamInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}