namespace NetMaster.Repository.Local.Powershell
{
    public class ShutdownPcRepository : BasePowershellRepository
    {
        private static readonly string command = "Stop-Computer";

        public async Task<string?> ShutdownPc(string ip)
        {
            return await RunCommand(command, ip, "-Force");
        }
    }
}