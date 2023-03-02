namespace NetMaster.Repository.Local.Powershell
{
    public class VerifyChocolateyRepository : BasePowershellRepository
    {
        private static readonly string command = "choco";

        public async Task<string?> VerifyChocolateyInstalled(string ip)
        {
            return await RunCommand(command, ip, "-v");
        }
    }
}