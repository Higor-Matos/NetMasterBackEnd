using NetMaster.Domain.Results;
using NetMaster.Repository.Local.Powershell;

namespace NetMaster.Services.Powershell
{
    public class PowershellServices
    {
        private readonly ShutdownPcRepository shutdownPcConectorRep = new();
        private readonly VerifyChocolateyRepository verifyChocolateyRep = new();
        private readonly RestartPcRepository restartPcConectorRep = new();

        public async Task<ResultServiceModel> ShutdownPcComand(string ip)
        {
            string? resultRep = await shutdownPcConectorRep.ShutdownPc(ip);
            if (resultRep != null)
            {
                return new ResultServiceModel(success: new SuccessResult(resultRep));
            }
            else
            {
                return new ResultServiceModel(error: new ErrorResult("Ocorreu um erro"));
            }
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
