// NetMaster.Services/Interfaces/Network/INetworkService.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;

namespace NetMaster.Services.Interfaces.Network
{
    [AutoDI]
    public interface INetworkService
    {
        NetworkComputer[] ListNetworkComputerCommand();
    }
}
