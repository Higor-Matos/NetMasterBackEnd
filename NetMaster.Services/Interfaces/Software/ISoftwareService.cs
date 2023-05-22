using NetMaster.Common;

namespace NetMaster.Services.Interfaces.Software
{
    [AutoDI]
    public interface ISoftwareService
    {
        Task InstallSoftware(string ip, string softwareName);
    }

}
