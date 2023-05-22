// NetMaster.Services/Interfaces/IFileDistributionService.cs

using NetMaster.Common;

namespace NetMaster.Services.Interfaces.BackgroundServices
{
    [AutoDI]

    public interface IFileDistributionService
    {
        Task DistributeFileToNetworkAsync(string filePath);
    }
}
