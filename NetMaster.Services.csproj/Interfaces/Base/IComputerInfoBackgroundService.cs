using NetMaster.Common;
using NetMaster.Services.Interfaces.Hardware;
using NetMaster.Services.Interfaces.System;
using System.Threading;
using System.Threading.Tasks;

namespace NetMaster.Services.Interfaces.BackgroundServices
{
    [AutoDI]
    public interface IComputerInfoBackgroundService
    {
        Task ExecuteAsync(CancellationToken stoppingToken);
        Task CollectAndStoreComputerInfoAsync();
        (ISystemService SystemService,
         IRamInfoService RamInfoService,
         IStorageInfoService StorageInfoService,
         IChocolateyInfoService ChocolateyInfoService,
         IInstalledProgramsInfoService InstalledProgramsInfoService,
         IOsVersionInfoService OsVersionInfoService,
         IUsersInfoService UserInfoService
        ) GetRequiredServices(IServiceProvider serviceProvider);
    }
}
