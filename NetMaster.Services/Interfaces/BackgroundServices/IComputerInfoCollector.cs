using NetMaster.Common;

namespace NetMaster.Services.Interfaces.BackgroundServices
{
    [AutoDI]
    public interface IComputerInfoCollector
    {
        Task CollectAndStoreComputerInfoAsync(string ip);

    }
}
