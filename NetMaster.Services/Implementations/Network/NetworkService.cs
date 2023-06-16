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
                new NetworkComputer { Name = "Erick-PC", IP = "192.168.100.17" },
                new NetworkComputer { Name = "NoteGustavo", IP = "192.168.100.15" },
                new NetworkComputer { Name = "RAMO-PC", IP = "192.168.100.16" },
            };

            return computersAndIPs;
        }
    }
}
