// NetMaster.Services/ComputerInfoBackgroundService.cs
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Services.Interfaces;

namespace NetMaster.Services
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
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        private async Task CollectAndStoreComputerInfoAsync()
        {
            NetworkComputer[] computers = _networkService.ListNetworkComputerComand();

            foreach (NetworkComputer computer in computers)
            {
                string ip = computer.IP;

                using IServiceScope scope = _serviceProvider.CreateScope();
                SystemService systemService = scope.ServiceProvider.GetRequiredService<SystemService>();
                IRamInfoService ramInfoService = scope.ServiceProvider.GetRequiredService<IRamInfoService>();
                IStorageInfoService storageInfoService = scope.ServiceProvider.GetRequiredService<IStorageInfoService>();

                if (systemService == null || ramInfoService == null || storageInfoService == null)
                {
                    throw new Exception("One or more required services are null.");
                }

                await ramInfoService.SaveLocalRamInfoAsync(ip);
                await storageInfoService.SaveLocalStorageInfoAsync(ip);
                await systemService.SaveLocalUsersInfoAsync(ip);
                await systemService.SaveLocalOSVersionInfoAsync(ip);
                await systemService.SaveLocalInstalledProgramsInfoAsync(ip);
            }
        }

    }
}
