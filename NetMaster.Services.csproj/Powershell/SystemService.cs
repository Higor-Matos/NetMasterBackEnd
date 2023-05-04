using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell.System;

namespace NetMaster.Services.Powershell
{
    public class SystemService : BaseService
    {
        private readonly ShutdownPcRepository shutdownPcConectorRepository = new();
        private readonly RestartPcRepository restartPcConectorRepository = new();
        private readonly UsersRepository getUsersRepository = new();
        private readonly OsVersionRepository getOsVersionRepository = new();
        private readonly VerifyChocolateyRepository verifyChocolateyRepository = new();
        private readonly InstalledProgramsRepository installedProgramsRepository = new();


        public async Task<ServiceResultModel<ChocolateyInfoModel>> VerifyChocolateyComand(string ip)
        {
            RepositoryResultModel<ChocolateyInfoModel> resultRep = await verifyChocolateyRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel<LocalUsersInfoModel>> GetUsers(string ip)
        {
            RepositoryResultModel<LocalUsersInfoModel> resultRep = await getUsersRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel<OSVersionInfoModel>> GetOsVersion(string ip)
        {
            RepositoryResultModel<OSVersionInfoModel> resultRep = await getOsVersionRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
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