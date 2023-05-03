
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell.System;
using Newtonsoft.Json.Linq;

namespace NetMaster.Services.Powershell.PowershellServices
{
    public class SystemService
    {
        private readonly ShutdownPcRepository shutdownPcConectorRep = new();
        private readonly RestartPcRepository restartPcConectorRep = new();
        private readonly GetUsersRepository getUsersRepository = new();
        private readonly GetOsVersionRepository getOsVersionRep = new();
        private readonly GetInstalledProgramsRepository getInstalledProgramsRep = new();
        private readonly VerifyChocolateyRepository verifyChocolateyRep = new();


        public async Task<ServiceResultModel<ChocolateyInfoModel>> VerifyChocolateyComand(string ip)
        {
            RepositoryResultModel<ChocolateyInfoModel> resultRep = await verifyChocolateyRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel<LocalUsersInfoModel>> GetUsers(string ip)
        {
            RepositoryResultModel<string> resultRep = await getUsersRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            DateTime timestamp = DateTime.UtcNow.ToLocalTime();


            if (resultRep.SuccessResult != null)
            {
                string jsonOutput = resultRep.SuccessResult.Result;

                if (string.IsNullOrWhiteSpace(jsonOutput))
                {
                    return new ServiceResultModel<LocalUsersInfoModel>(error: new ErrorServiceResult("A saída do comando PowerShell está vazia.", timestamp, Environment.MachineName));
                }

                JObject resultJson = JObject.Parse(jsonOutput);
                List<LocalUser> localUsers = resultJson["Users"].ToObject<List<LocalUser>>();
                string computerName = resultJson["PSComputerName"].ToString();

                LocalUsersInfoModel localUsersResponse = new LocalUsersInfoModel
                {
                    Users = localUsers,
                    PSComputerName = computerName,
                    Timestamp = timestamp.ToString("yyyy-MM-ddTHH:mm:ss"),
                    IpAddress = ip
                };
                return new ServiceResultModel<LocalUsersInfoModel>(success: new SuccessServiceResult<LocalUsersInfoModel>(localUsersResponse, timestamp, computerName));
            }
            else
            {
                string msgError = resultRep.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                return new ServiceResultModel<LocalUsersInfoModel>(error: new ErrorServiceResult(msgError, timestamp, Environment.MachineName));
            }
        }

        public async Task<ServiceResultModel<OSVersionInfoModel>> GetOsVersion(string ip)
        {
            RepositoryResultModel<OSVersionInfoModel> resultRep = await getOsVersionRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel<InstalledProgramsResponse>> GetInstalledPrograms(string ip)
        {
            RepositoryResultModel<InstalledProgramsResponse> resultRep = await getInstalledProgramsRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            DateTime timestamp = DateTime.UtcNow.ToLocalTime();

            if (resultRep.SuccessResult != null)
            {
                InstalledProgramsResponse installedProgramsResponse = resultRep.SuccessResult.Result;
                return new ServiceResultModel<InstalledProgramsResponse>(success: new SuccessServiceResult<InstalledProgramsResponse>(installedProgramsResponse, timestamp, installedProgramsResponse.PSComputerName));
            }
            else
            {
                string msgError = resultRep.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                return new ServiceResultModel<InstalledProgramsResponse>(error: new ErrorServiceResult(msgError, timestamp, Environment.MachineName));
            }
        }

        public async Task<ServiceResultModel<object>> ShutdownPcComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await shutdownPcConectorRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }

        public async Task<ServiceResultModel<object>> RestartPcComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await restartPcConectorRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }


        private static ServiceResultModel<T> RunCommand<T>(RepositoryResultModel<T> result)
        {
            DateTime timestamp = DateTime.UtcNow;
            string computerName = Environment.MachineName;

            if (result.SuccessResult != null)
            {
                return new ServiceResultModel<T>(success: new SuccessServiceResult<T>(result.SuccessResult.Result, timestamp, computerName));
            }
            else
            {
                string msgError = result.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                return new ServiceResultModel<T>(error: new ErrorServiceResult(msgError, timestamp, computerName));
            }
        }
        private static RepositoryResultModel<object> ConvertResult(RepositoryResultModel<string> result)
        {
            if (result.SuccessResult != null)
            {
                return new RepositoryResultModel<object>(new SuccessRepositoryResult<object>(result.SuccessResult.Result), result.ErrorResult);
            }
            else
            {
                return new RepositoryResultModel<object>(null, result.ErrorResult);
            }
        }

    }
}