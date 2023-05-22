﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetMaster.Services.Interfaces.BackgroundServices;

namespace NetMaster.Services.Implementations.BackgroundServices
{
    public class FileMonitorBackgroundService : BackgroundService, IFileMonitorBackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly string _path;
        private readonly FileSystemWatcher _watcher;

        public FileMonitorBackgroundService(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
            _path = _configuration["UploadsDirectory"];
            _watcher = new FileSystemWatcher(_path);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ = stoppingToken.Register(() => OnStopping());

            _watcher.Created += OnCreated;
            _watcher.EnableRaisingEvents = true;

            return Task.CompletedTask;
        }

        private void OnStopping()
        {
            _watcher.EnableRaisingEvents = false;
            _watcher.Created -= OnCreated;
            _watcher.Dispose();
        }

        private async void OnCreated(object sender, FileSystemEventArgs e)
        {
            using IServiceScope scope = _serviceProvider.CreateScope();
            IFileDistributionService fileDistributionService = scope.ServiceProvider.GetRequiredService<IFileDistributionService>();

            await fileDistributionService.DistributeFileToNetworkAsync(e.FullPath);
        }
    }
}