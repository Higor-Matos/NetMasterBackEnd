//NetMaster.Repository/Interfaces/Software/IInstallAdobeReaderRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.Software
{
    [AutoDI]
    public interface IInstallWinrarRepository
    {
        Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
