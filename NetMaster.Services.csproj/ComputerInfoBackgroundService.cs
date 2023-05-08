using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetMaster.Domain.Models.DataModels;
using System.Threading;
using System.Threading.Tasks;

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

                using (var scope = _serviceProvider.CreateScope())
                {
                    var hardwareService = scope.ServiceProvider.GetRequiredService<HardwareService>();
                    await hardwareService.SaveLocalRamInfoAsync(ip);
                    await hardwareService.SaveLocalStorageInfoAsync(ip);
                }
            }
        }
    }
}
