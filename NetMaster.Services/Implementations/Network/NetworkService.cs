// NetMaster.Services/Implementations/Network/NetworkService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Services.Interfaces.Network;

namespace NetMaster.Services.Implementations.Network
{
    public class NetworkService : INetworkService
    {
        public NetworkComputer[] ListNetworkComputerCommand()
        {
            NetworkComputer[] computersAndIPs = new NetworkComputer[]
            {
                //new NetworkComputer { Name = "Higor-PC", IP = "192.168.0.3" },
                new NetworkComputer { Name = "MagnaTI-10848-FRAMEWORK", IP = "192.168.100.15" },
                //new NetworkComputer { Name = "RAMO-PC", IP = "192.168.100.16" },
            };

            return computersAndIPs;
        }
    }
}
