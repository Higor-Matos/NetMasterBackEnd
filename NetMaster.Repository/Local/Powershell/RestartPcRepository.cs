
namespace NetMaster.Repository.Local.Powershell
{
    public class RestartPcRepository : BasePowershellRepository
    {
        public async Task<string> RestartPc(string ip)
        {
            string command = "Restart-Computer";

            return await RunCommand(command, ip, "-Force");
        }
    }
}