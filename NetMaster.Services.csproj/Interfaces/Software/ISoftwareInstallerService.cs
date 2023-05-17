// NetMaster.Services/Interfaces/Software/ISoftwareInstallerService.cs
using NetMaster.Common;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.Software
{
    [AutoDI]
    public interface ISoftwareInstallerService
    {
        Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip);
    }
}
