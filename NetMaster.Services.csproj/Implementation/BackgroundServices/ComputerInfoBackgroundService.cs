// NetMaster.Services/Implementations/ComputerInfoBackgroundServices.cs
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Services.Implementations.Network;
using NetMaster.Services.Interfaces.Hardware;
using NetMaster.Services.Interfaces.System;

namespace NetMaster.Services.Implementation.BackgroundServices
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

                (SystemService SystemService, IRamInfoService RamInfoService, IStorageInfoService StorageInfoService, IChocolateyInfoService ChocolateyInfoService, IInstalledProgramsInfoService InstalledProgramsInfoService, IOsVersionInfoService OsVersionInfoService, IUsersInfoService UserInfoService) services = GetRequiredServices(scope.ServiceProvider);

                List<Task> tasks = new()
                {
                    services.RamInfoService.SaveLocalRamInfoAsync(ip),
                    services.StorageInfoService.SaveLocalStorageInfoAsync(ip),
                    services.UserInfoService.SaveLocalSystemInfoAsync(ip),
                    services.OsVersionInfoService.SaveLocalSystemInfoAsync(ip),
                    services.InstalledProgramsInfoService.SaveLocalSystemInfoAsync(ip),
                    services.ChocolateyInfoService.SaveLocalSystemInfoAsync(ip)
                };

                await Task.WhenAll(tasks);
            }
        }

        private (
            SystemService SystemService,
            IRamInfoService RamInfoService,
            IStorageInfoService StorageInfoService,
            IChocolateyInfoService ChocolateyInfoService,
            IInstalledProgramsInfoService InstalledProgramsInfoService,
            IOsVersionInfoService OsVersionInfoService,
            IUsersInfoService UserInfoService
        ) GetRequiredServices(IServiceProvider serviceProvider)
        {
            SystemService systemService = serviceProvider.GetRequiredService<SystemService>();
            IRamInfoService ramInfoService = serviceProvider.GetRequiredService<IRamInfoService>();
            IStorageInfoService storageInfoService = serviceProvider.GetRequiredService<IStorageInfoService>();
            IChocolateyInfoService chocolateyInfoService = serviceProvider.GetRequiredService<IChocolateyInfoService>();
            IInstalledProgramsInfoService installedProgramsInfoService = serviceProvider.GetRequiredService<IInstalledProgramsInfoService>();
            IOsVersionInfoService osVersionInfoService = serviceProvider.GetRequiredService<IOsVersionInfoService>();
            IUsersInfoService usersInfoService = serviceProvider.GetRequiredService<IUsersInfoService>();

            return (
                systemService,
                ramInfoService,
                storageInfoService,
                chocolateyInfoService,
                installedProgramsInfoService,
                osVersionInfoService,
                usersInfoService
            );
        }


    }
}
