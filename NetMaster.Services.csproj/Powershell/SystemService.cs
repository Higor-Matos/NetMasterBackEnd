using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell.Software;
using NetMaster.Repository.Local.Powershell.System;

namespace NetMaster.Services.Powershell.PowershellServices
{
    public class SystemService
    {
        private readonly ShutdownPcRepository shutdownPcConectorRep = new();
        private readonly RestartPcRepository restartPcConectorRep = new();
        private readonly GetUsersRepository getUsersRepository = new();
        private readonly GetOsVersionRepository getOsVersionRep = new();
        private readonly GetInstalledProgramsRepository getInstalledProgramsRep = new();

        public async Task<ServiceResultModel> GetUsers(string ip)
        {
            RepositoryResultModel resultRep = await getUsersRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel> GetOsVersion(string ip)
        {
            RepositoryResultModel resultRep = await getOsVersionRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel> GetInstalledPrograms(string ip)
        {
            RepositoryResultModel resultRep = await getInstalledProgramsRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }


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

        private static ServiceResultModel RunCommand(RepositoryResultModel result)
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
