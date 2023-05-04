using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.System;

namespace NetMaster.Services
{
    public class SystemService : BaseService
    {
        private readonly ShutdownPcRepository shutdownPcConectorRepository = new();
        private readonly RestartPcRepository restartPcConectorRepository = new();
        private readonly UsersRepository getUsersRepository = new();
        private readonly OsVersionRepository getOsVersionRepository = new();
        private readonly VerifyChocolateyRepository verifyChocolateyRepository = new();
        private readonly InstalledProgramsRepository installedProgramsRepository = new();


        public async Task<ServiceResultModel<ChocolateyInfoDataModel>> VerifyChocolateyComand(string ip)
        {
            RepositoryResultModel<ChocolateyInfoDataModel> resultRep = await verifyChocolateyRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel<LocalUsersInfoDataModel>> GetUsers(string ip)
        {
            RepositoryResultModel<LocalUsersInfoDataModel> resultRep = await getUsersRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel<OSVersionInfoDataModel>> GetOsVersion(string ip)
        {
            RepositoryResultModel<OSVersionInfoDataModel> resultRep = await getOsVersionRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel<InstalledProgramsResponseModel>> GetInstalledPrograms(string ip)
        {
            RepositoryResultModel<InstalledProgramsResponseModel> resultRep = await installedProgramsRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel<object>> ShutdownPcComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await shutdownPcConectorRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }

        public async Task<ServiceResultModel<object>> RestartPcComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await restartPcConectorRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}