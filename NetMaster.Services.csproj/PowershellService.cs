namespace NetMaster.Services
{
    public class PowershellService
    {
        public object[] ListNetworkComputerComand()
        {
            object[] computersAndIPs = new object[]
            {
                new { Name = "Higor-PC", IP = "192.168.0.3" },
                new { Name = "Gustavo-PC", IP = "192.168.0.4" },
                new { Name = "Convidado-PC", IP = "192.168.0.10" },
            };

            return computersAndIPs;
        }
    }
}
