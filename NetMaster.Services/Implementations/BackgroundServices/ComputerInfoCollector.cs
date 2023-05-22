// NetMaster.Presentation.Services.Collectors.ComputerInfoCollector.cs
using Microsoft.Extensions.DependencyInjection;
using NetMaster.Services.Interfaces.Hardware;
using NetMaster.Services.Interfaces.Network;
using NetMaster.Services.Interfaces.System;

namespace NetMaster.Presentation.Services.Collectors
{
    public class ComputerInfoCollector
    {
        private readonly IServiceProvider _serviceProvider;

        public ComputerInfoCollector(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task CollectAndStoreComputerInfoAsync(string ip)
        {
            using IServiceScope scope = _serviceProvider.CreateScope();

            (
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

        private (
            IRamInfoService RamInfoService,
            IStorageInfoService StorageInfoService,
            IChocolateyInfoService ChocolateyInfoService,
            IInstalledProgramsInfoService InstalledProgramsInfoService,
            IOsVersionInfoService OsVersionInfoService,
            IUsersInfoService UserInfoService
        ) GetRequiredServices(IServiceProvider serviceProvider)
        {
            IRamInfoService ramInfoService = serviceProvider.GetRequiredService<IRamInfoService>();
            IStorageInfoService storageInfoService = serviceProvider.GetRequiredService<IStorageInfoService>();
            IChocolateyInfoService chocolateyInfoService = serviceProvider.GetRequiredService<IChocolateyInfoService>();
            IInstalledProgramsInfoService installedProgramsInfoService = serviceProvider.GetRequiredService<IInstalledProgramsInfoService>();
            IOsVersionInfoService osVersionInfoService = serviceProvider.GetRequiredService<IOsVersionInfoService>();
            IUsersInfoService usersInfoService = serviceProvider.GetRequiredService<IUsersInfoService>();

            return (
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