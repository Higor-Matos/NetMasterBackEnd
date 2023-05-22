namespace NetMaster.Services.Interfaces.Base
{
    public interface IComputerInfoBackgroundService
    {
        Task ExecuteAsync(CancellationToken stoppingToken);
        Task CollectAndStoreComputerInfoAsync();
    }
}
