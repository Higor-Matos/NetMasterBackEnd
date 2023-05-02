using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell.Software;
using NetMaster.Repository.Local.Powershell.System;
using Newtonsoft.Json;
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

        public async Task<ServiceResultModel<LocalUsersResponse>> GetUsers(string ip)
        {
            RepositoryResultModel<string> resultRep = await getUsersRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            DateTime timestamp = DateTime.UtcNow;

            if (resultRep.SuccessResult != null)
            {
                JObject resultJson = JObject.Parse(resultRep.SuccessResult.Result);
                List<LocalUser> localUsers = resultJson["Users"].ToObject<List<LocalUser>>();
                string computerName = resultJson["PSComputerName"].ToString();

                LocalUsersResponse localUsersResponse = new LocalUsersResponse
                {
                    Users = localUsers,
                    PSComputerName = computerName,
                    Timestamp = timestamp.ToString(),
                    IpAddress = ip
                };
                return new ServiceResultModel<LocalUsersResponse>(success: new SuccessServiceResult<LocalUsersResponse>(localUsersResponse, timestamp, computerName));
            }
            else
            {
                string msgError = resultRep.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                return new ServiceResultModel<LocalUsersResponse>(error: new ErrorServiceResult(msgError, timestamp, Environment.MachineName));
            }
        }


        public async Task<ServiceResultModel<object>> GetOsVersion(string ip)
        {
            RepositoryResultModel<string> resultRep = await getOsVersionRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }

        public async Task<ServiceResultModel<object>> GetInstalledPrograms(string ip)
        {
            RepositoryResultModel<string> resultRep = await getInstalledProgramsRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
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

        private static ServiceResultModel<object> RunCommand(RepositoryResultModel<object> result)
        {
            DateTime timestamp = DateTime.UtcNow;
            string computerName = Environment.MachineName;

            if (result.SuccessResult != null)
            {
                return new ServiceResultModel<object>(success: new SuccessServiceResult<object>(result.SuccessResult.Result, timestamp, computerName));
            }
            else
            {
                string msgError = result.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                return new ServiceResultModel<object>(error: new ErrorServiceResult(msgError, timestamp, computerName));
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
