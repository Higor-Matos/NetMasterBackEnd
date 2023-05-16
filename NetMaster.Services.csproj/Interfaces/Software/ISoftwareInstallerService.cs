// NetMaster.Services/Interfaces/Software/ISoftwareInstallerService.cs
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.Software
{
    public interface ISoftwareInstallerService
    {
        Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip);
    }
}
