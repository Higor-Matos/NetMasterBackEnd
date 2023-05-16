// NetMaster.Services/Implementations/ComputerInfoBackgroundService.cs
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Services.Implementations.Network;
using NetMaster.Services.Interfaces.Hardware;

namespace NetMaster.Services.Implementations.BackgroundServices
{
    public class ComputerInfoBackgroundService : BackgroundService
    {
        private readonly NetworkService _networkService;
        private readonly IServiceProvider _serviceProvider;

        public ComputerInfoBackgroundService(NetworkService networkService, IServiceProvider serviceProvider)
        {
            _networkService = networkService;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await CollectAndStoreComputerInfoAsync();
                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            }
        }

        private async Task CollectAndStoreComputerInfoAsync()
        {
            NetworkComputer[] computers = _networkService.ListNetworkComputerCommand();

            foreach (NetworkComputer computer in computers)
            {
                string ip = computer.IP;

                using IServiceScope scope = _serviceProvider.CreateScope();

                (SystemService SystemService, IRamInfoService RamInfoService, IStorageInfoService StorageInfoService) services = GetRequiredServices(scope.ServiceProvider);

                List<Task> tasks = new()
                {
                    services.RamInfoService.SaveLocalRamInfoAsync(ip),
                    services.StorageInfoService.SaveLocalStorageInfoAsync(ip),
                    services.SystemService.SaveLocalUsersInfoAsync(ip),
                    services.SystemService.SaveLocalOSVersionInfoAsync(ip),
                    services.SystemService.SaveLocalInstalledProgramsInfoAsync(ip),
                    services.SystemService.SaveLocalChocolateyInfoAsync(ip)
                };

                await Task.WhenAll(tasks);
            }
        }

        private (SystemService SystemService, IRamInfoService RamInfoService, IStorageInfoService StorageInfoService) GetRequiredServices(IServiceProvider serviceProvider)
        {
            SystemService systemService = serviceProvider.GetRequiredService<SystemService>();
            IRamInfoService ramInfoService = serviceProvider.GetRequiredService<IRamInfoService>();
            IStorageInfoService storageInfoService = serviceProvider.GetRequiredService<IStorageInfoService>();

            return (systemService, ramInfoService, storageInfoService);
        }
    }
}
