using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell;

namespace NetMaster.Services.Powershell
{
    public class PowershellServices
    {
        private readonly ShutdownPcRepository shutdownPcConectorRep = new();
        private readonly RestartPcRepository restartPcConectorRep = new();
        private readonly VerifyChocolateyRepository verifyChocolateyRep = new();

        public async Task<ServiceResultModel> ShutdownPcComand(string ip)
        {
            RepositoryResultModel resultRep = await shutdownPcConectorRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel> RestartPcComand(string ip)
        {
            RepositoryResultModel resultRep = await restartPcConectorRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel> VerifyChocolateyComand(string ip)
        {
            RepositoryResultModel resultRep = await verifyChocolateyRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);

        }

        private ServiceResultModel RunCommand(RepositoryResultModel result)
        {
            if (result.SuccessResult != null)
            {
                return new ServiceResultModel(success: new SuccessServiceResult(result.SuccessResult.Result));
            }
            else
            {
                string msgError = result.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                return new ServiceResultModel(error: new ErrorServiceResult(msgError));
            }
        }
    }
}
