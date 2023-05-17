// NetMaster.Repository/Interfaces/ILocalChocolateyRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface ILocalChocolateyRepository : ILocalSystemRepository<ChocolateyInfoDataModel>
    {
        Task<RepositoryResultModel<ChocolateyInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}