// NetMaster.Services/Interfaces/Network/INetworkService.cs
using NetMaster.Domain.Models.DataModels;

namespace NetMaster.Services.Interfaces
{
    public interface INetworkService
    {
        NetworkComputer[] ListNetworkComputerCommand();
    }
}
