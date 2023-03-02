
namespace NetMaster.Repository.Local.Powershell
{
    public class RestartPcRepository : BasePowershellRepository
    {
        private static readonly string command = "Restart-Computer";

        public async Task<string?> RestartPc(string ip)
        {
            return await RunCommand(command, ip, "-Force");
        }
    }
}