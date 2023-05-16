//NetMaster.Repository/Interfaces/Software/IInstallFirefoxRepository.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.Software
{
    public interface IInstallFirefoxRepository
    {
        Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
