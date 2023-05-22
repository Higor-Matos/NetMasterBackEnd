// NetMaster.Presentation.Services.ComputerInfoBackgroundService.cs
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetMaster.Services.Interfaces.Network;
using NetMaster.Presentation.Services.Collectors;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Services.Interfaces.BackgroundServices;
using NetMaster.Services.Interfaces.Base;

namespace NetMaster.Presentation.Services
{
    public class ComputerInfoBackgroundService : BackgroundService, IComputerInfoBackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ComputerInfoCollector _computerInfoCollector;
        private readonly INetworkService _networkService;

        public ComputerInfoBackgroundService(
            IServiceProvider serviceProvider,
            ComputerInfoCollector computerInfoCollector,
            INetworkService networkService)
        {
            _serviceProvider = serviceProvider;
            _computerInfoCollector = computerInfoCollector;
            _networkService = networkService;
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
                    await _computerInfoCollector.CollectAndStoreComputerInfoAsync(ip);
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
    }
}