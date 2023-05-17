//NetMaster.Repository/Interfaces/Software/IInstallFirefoxRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.Software
{
    [AutoDI]
    public interface IInstallFirefoxRepository
    {
        Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
