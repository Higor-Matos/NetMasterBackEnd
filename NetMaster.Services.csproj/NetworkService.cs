using NetMaster.Domain.Models.DataModels;

namespace NetMaster.Services
{
    public class NetworkService
    {
        public NetworkComputer[] ListNetworkComputerComand()
        {
            NetworkComputer[] computersAndIPs = new NetworkComputer[]
            {
                new NetworkComputer { Name = "Higor-PC", IP = "192.168.0.3" },
                new NetworkComputer { Name = "Gustavo-PC", IP = "192.168.0.4" },
                new NetworkComputer { Name = "RAMO-PC", IP = "192.168.100.16" },
            };

            return computersAndIPs;
        }
    }
}
