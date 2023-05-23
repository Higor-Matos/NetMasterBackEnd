// NetMaster.Services/Implementations/ComputerInfoBackgroundServices.cs

using NetMaster.Common;
using NetMaster.Services.Interfaces.Network;

namespace NetMaster.Services.Interfaces.BackgroundServices
{
    [AutoDI]
    internal interface IComputerInfoBackgroundService
    {
        Task CollectAndStoreComputerInfoAsync(INetworkService networkService);

    }
}