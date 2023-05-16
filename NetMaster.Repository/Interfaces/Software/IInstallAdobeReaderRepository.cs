//NetMaster.Repository/Interfaces/Software/IInstallAdobeReaderRepository.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.Software
{
    public interface IInstallAdobeReaderRepository
    {
        Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
