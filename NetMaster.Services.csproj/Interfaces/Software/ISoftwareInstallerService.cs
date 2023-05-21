// NetMaster.Services/Interfaces/Software/ISoftwareInstallerService.cs
using NetMaster.Common;
using NetMaster.Domain.Models.Results.Service;

namespace NetMaster.Services.Interfaces.Software
{
    [AutoDI]
    public interface ISoftwareInstallerService
    {
        Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip, string softwareName);

    }
}
