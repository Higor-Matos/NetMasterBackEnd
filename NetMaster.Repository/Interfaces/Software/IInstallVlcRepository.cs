//NetMaster.Repository/Interfaces/Software/IInstalVlcRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.Software
{
    [AutoDI]
    public interface IInstallVlcRepository
    {
        Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
