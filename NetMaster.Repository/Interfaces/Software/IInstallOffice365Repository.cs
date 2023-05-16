//NetMaster.Repository/Interfaces/Software/IInstallOffice365Repository.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.Software
{
    public interface IInstallOffice365Repository
    {
        Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
