namespace NetMaster.Services
{
    public class ComputerInfoCollectorService
    {
        private readonly SystemService _systemService;
        private readonly HardwareService _hardwareService;

        public ComputerInfoCollectorService(SystemService systemService, HardwareService hardwareService)
        {
            _systemService = systemService;
            _hardwareService = hardwareService;
        }

        public async Task CollectAndStoreAsync(string ip)
        {
            await _hardwareService.SaveLocalRamInfoAsync(ip);
            await _hardwareService.SaveLocalStorageInfoAsync(ip);
            await _systemService.SaveLocalUsersInfoAsync(ip);
            await _systemService.SaveLocalOSVersionInfoAsync(ip);
            await _systemService.SaveLocalInstalledProgramsInfoAsync(ip);
            await _systemService.SaveLocalChocolateyInfoAsync(ip);
        }
    }
}

