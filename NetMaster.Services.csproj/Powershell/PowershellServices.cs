using NetMaster.Repository.Local.Powershell;

namespace NetMaster.Services.Powershell
{
    public class PowershellServices
    {
        private readonly ShutdownPcRepository shutdownPcConectorRep = new();
        private readonly VerifyChocolateyRepository verifyChocolateyRep = new();
        private readonly RestartPcRepository restartPcConectorRep = new();

        public async Task<string> ShutdownPcComand(string ip)
        {
            return await shutdownPcConectorRep.ShutdownPc(ip);
        }

        public async Task<string> RestartPcComand(string ip)
        {
            return await restartPcConectorRep.RestartPc(ip);
        }

        public async Task<string> VerifyChocolateyComand(string ip)
        {
            return await verifyChocolateyRep.VerifyChocolateyInstalled(ip);
        }

    }

}
