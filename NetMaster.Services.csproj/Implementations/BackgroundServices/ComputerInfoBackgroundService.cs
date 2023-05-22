// NetMaster.Services/Implementations/ComputerInfoBackgroundServices.cs
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Services.Interfaces.BackgroundServices;
using NetMaster.Services.Interfaces.Hardware;
using NetMaster.Services.Interfaces.Network;
using NetMaster.Services.Interfaces.System;

namespace NetMaster.Services.Implementations.BackgroundServices
{
    public class ComputerInfoBackgroundService : BackgroundService, IComputerInfoBackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ComputerInfoBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using IServiceScope scope = _serviceProvider.CreateScope();
                INetworkService networkService = scope.ServiceProvider.GetRequiredService<INetworkService>();

                await CollectAndStoreComputerInfoAsync(networkService);
                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            }
        }

        private async Task CollectAndStoreComputerInfoAsync(INetworkService networkService)
        {
            NetworkComputer[]? computers = networkService.ListNetworkComputerCommand();

            foreach (NetworkComputer? computer in computers)
            {
                string? ip = computer?.IP;

                if (ip != null)
                {
                    using IServiceScope scope = _serviceProvider.CreateScope();

                    (
                        ISystemService ISystemService,
                        IRamInfoService RamInfoService,
                        IStorageInfoService StorageInfoService,
                        IChocolateyInfoService ChocolateyInfoService,
                        IInstalledProgramsInfoService InstalledProgramsInfoService,
                        IOsVersionInfoService OsVersionInfoService,
                        IUsersInfoService UserInfoService
                    ) services = GetRequiredServices(scope.ServiceProvider);

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
        }

        Task IComputerInfoBackgroundService.CollectAndStoreComputerInfoAsync()
        {
            throw new NotImplementedException();
        }

        Task IComputerInfoBackgroundService.ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }

        private (
            ISystemService SystemService,
            IRamInfoService RamInfoService,
            IStorageInfoService StorageInfoService,
            IChocolateyInfoService ChocolateyInfoService,
            IInstalledProgramsInfoService InstalledProgramsInfoService,
            IOsVersionInfoService OsVersionInfoService,
            IUsersInfoService UserInfoService
        ) GetRequiredServices(IServiceProvider serviceProvider)
        {
            ISystemService systemService = serviceProvider.GetRequiredService<ISystemService>();
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

        (ISystemService SystemService, IRamInfoService RamInfoService, IStorageInfoService StorageInfoService, IChocolateyInfoService ChocolateyInfoService, IInstalledProgramsInfoService InstalledProgramsInfoService, IOsVersionInfoService OsVersionInfoService, IUsersInfoService UserInfoService) IComputerInfoBackgroundService.GetRequiredServices(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}
