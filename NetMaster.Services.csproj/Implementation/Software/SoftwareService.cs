// NetMaster.Services/Implementations/SoftwareSoftwareService.cs
using NetMaster.Services.Interfaces.Software;

namespace NetMaster.Services.Implementations.Software
{
    public class SoftwareService
    {
        private readonly Dictionary<string, ISoftwareInstallerService> _installerServices;

        public SoftwareService(Dictionary<string, ISoftwareInstallerService> installerServices)
        {
            _installerServices = installerServices;
        }

        public async Task InstallSoftware(string ip, string softwareName)
        {
            _ = _installerServices.TryGetValue(softwareName, out ISoftwareInstallerService? installerService)
                ? await installerService.InstallSoftwareCommand(ip)
                : throw new ArgumentException($"No installer found for software: {softwareName}", nameof(softwareName));
        }
    }
}

