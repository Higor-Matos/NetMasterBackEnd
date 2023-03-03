using NetMaster.Domain.Results;
using NetMaster.Repository.Local.Powershell;

namespace NetMaster.Services.Powershell
{
    public class PowershellServices
    {
        private readonly ShutdownPcRepository shutdownPcConectorRep = new();
        private readonly RestartPcRepository restartPcConectorRep = new();
        private readonly VerifyChocolateyRepository verifyChocolateyRep = new();

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

        public async Task<ResultServiceModel> RestartPcComand(string ip)
        {
            string? resultRep = await restartPcConectorRep.RestartPc(ip);
            if (resultRep != null)
            {
                return new ResultServiceModel(success: new SuccessResult(resultRep));
            }
            else
            {
                return new ResultServiceModel(error: new ErrorResult("Ocorreu um erro"));
            }
        }

        public async Task<ResultServiceModel> VerifyChocolateyComand(string ip)
        {
            string? resultRep = await verifyChocolateyRep.VerifyChocolateyInstalled(ip);
            if (resultRep != null)
            {
                return new ResultServiceModel(success: new SuccessResult(resultRep));
            }
            else
            {
                return new ResultServiceModel(error: new ErrorResult("Ocorreu um erro"));
            };
        }

    }

}
