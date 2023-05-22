// NetMaster.Repository/Interfaces/ILocalChocolateyRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface ILocalChocolateyRepository : ILocalSystemRepository<ChocolateyInfoDataModel>
    {
        new Task<RepositoryResultModel<ChocolateyInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}