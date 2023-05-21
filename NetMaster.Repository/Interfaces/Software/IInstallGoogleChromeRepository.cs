//NetMaster.Repository/Interfaces/Software/IInstallGoogleChromeRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;

namespace NetMaster.Repository.Interfaces.Software
{
    [AutoDI]
    public interface IInstallGoogleChromeRepository
    {
        Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
