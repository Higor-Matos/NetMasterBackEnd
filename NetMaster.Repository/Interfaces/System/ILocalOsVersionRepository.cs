// NetMaster.Repository/Interfaces/ILocalOsVersionRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface ILocalOsVersionRepository : ILocalSystemRepository<OSVersionInfoDataModel>
    {
        Task<RepositoryResultModel<OSVersionInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}