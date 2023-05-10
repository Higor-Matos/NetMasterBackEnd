// NetMaster.Service/SystemService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository;
using NetMaster.Repository.Local.System;

namespace NetMaster.Services
{
    public class SystemService : BaseService
    {
        private readonly IBaseRepository<ChocolateyInfoDataModel> _chocolateyRepository;
        private readonly IBaseRepository<UsersInfoDataModel> _usersRepository;
        private readonly IBaseRepository<OSVersionInfoDataModel> _osVersionRepository;
        private readonly IBaseRepository<InstalledProgramsResponseModel> _installedProgramsRepository;
        private readonly LocalChocolateyRepository _localChocolateyRepository;
        private readonly LocalUsersRepository _localUsersRepository;
        private readonly LocalOsVersionRepository _localOsVersionRepository;
        private readonly LocalInstalledProgramsRepository _localInstalledProgramsRepository;

        public SystemService(
            IBaseRepository<ChocolateyInfoDataModel> chocolateyRepository,
            IBaseRepository<UsersInfoDataModel> usersRepository,
            IBaseRepository<OSVersionInfoDataModel> osVersionRepository,
            IBaseRepository<InstalledProgramsResponseModel> installedProgramsRepository,
            LocalChocolateyRepository localChocolateyRepository,
            LocalUsersRepository localUsersRepository,
            LocalOsVersionRepository localOsVersionRepository,
            LocalInstalledProgramsRepository localInstalledProgramsRepository)
        {
            _chocolateyRepository = chocolateyRepository;
            _usersRepository = usersRepository;
            _osVersionRepository = osVersionRepository;
            _installedProgramsRepository = installedProgramsRepository;
            _localChocolateyRepository = localChocolateyRepository;
            _localUsersRepository = localUsersRepository;
            _localOsVersionRepository = localOsVersionRepository;
            _localInstalledProgramsRepository = localInstalledProgramsRepository;
        }

        public async Task SaveLocalChocolateyInfoAsync(string ip)
        {
            RepositoryResultModel<ChocolateyInfoDataModel> localChocolateyInfoResult = await _localChocolateyRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            if (localChocolateyInfoResult.SuccessResult != null)
            {
                ChocolateyInfoDataModel chocolateyInfo = localChocolateyInfoResult.SuccessResult.Result;
                if (!string.IsNullOrEmpty(chocolateyInfo.ChocolateyVersion))
                {
                    await _chocolateyRepository.InsertAsync(chocolateyInfo);
                }
            }
        }

        public async Task SaveLocalUsersInfoAsync(string ip)
        {
            RepositoryResultModel<UsersInfoDataModel> localUsersInfoResult = await _localUsersRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            if (localUsersInfoResult.SuccessResult != null)
            {
                await _usersRepository.InsertAsync(localUsersInfoResult.SuccessResult.Result);
            }
        }

        public async Task SaveLocalOSVersionInfoAsync(string ip)
        {
            RepositoryResultModel<OSVersionInfoDataModel> localOSVersionInfoResult = await _localOsVersionRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            if (localOSVersionInfoResult.SuccessResult != null)
            {
                await _osVersionRepository.InsertAsync(localOSVersionInfoResult.SuccessResult.Result);
            }
        }

        public async Task SaveLocalInstalledProgramsInfoAsync(string ip)
        {
            RepositoryResultModel<InstalledProgramsResponseModel> localInstalledProgramsInfoResult = await _localInstalledProgramsRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            if (localInstalledProgramsInfoResult.SuccessResult != null)
            {
                await _installedProgramsRepository.InsertAsync(localInstalledProgramsInfoResult.SuccessResult.Result);
            }
        }

        public async Task<ServiceResultModel<ChocolateyInfoDataModel>> VerifyChocolateyComand(string ip)
        {
            ChocolateyInfoDataModel chocolateyInfo = await _chocolateyRepository.GetByComputerNameAsync(ip);
            return CreateServiceResult(chocolateyInfo, "Não foi possível verificar o comando Chocolatey.", ip);
        }

        public async Task<ServiceResultModel<UsersInfoDataModel>> GetUsers(string ip)
        {
            UsersInfoDataModel usersInfo = await _usersRepository.GetByComputerNameAsync(ip);
            return CreateServiceResult(usersInfo, "Não foi possível obter informações dos usuários locais.", ip);
        }

        public async Task<ServiceResultModel<OSVersionInfoDataModel>> GetOsVersion(string ip)
        {
            OSVersionInfoDataModel osVersionInfo = await _osVersionRepository.GetByComputerNameAsync(ip);
            return CreateServiceResult(osVersionInfo, "Não foi possível obter informações da versão do sistema operacional.", ip);
        }

        public async Task<ServiceResultModel<InstalledProgramsResponseModel>> GetInstalledPrograms(string ip)
        {
            InstalledProgramsResponseModel installedProgramsInfo = await _installedProgramsRepository.GetByComputerNameAsync(ip);
            return CreateServiceResult(installedProgramsInfo, "Não foi possível obter informações dos programas instalados.", ip);
        }

        public async Task<ServiceResultModel<object>> ShutdownPcComand(string ip, ShutdownPcRepository shutdownPcRepository)
        {
            RepositoryResultModel<string> resultRep = await shutdownPcRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }

        public async Task<ServiceResultModel<object>> RestartPcComand(string ip, RestartPcRepository restartPcRepository)
        {
            RepositoryResultModel<string> resultRep = await restartPcRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }

        private ServiceResultModel<T> CreateServiceResult<T>(T data, string errorMessage, string ip) where T : BaseInfoDataModel
        {
            return data != null
                ? new ServiceResultModel<T>(
                    success: new SuccessServiceResult<T>(data, DateTime.UtcNow, ip)
                )
                : new ServiceResultModel<T>(
                    error: new ErrorServiceResult(errorMessage, DateTime.UtcNow, ip)
                );
        }

        public async Task<ServiceResultModel<object>> GetInfoAsync(string infoType, string computerName)
        {
            object? info = infoType.ToLowerInvariant() switch
            {
                "users" => await _usersRepository.GetMostRecentByComputerNameAsync(computerName),
                "chocolatey" => await _chocolateyRepository.GetMostRecentByComputerNameAsync(computerName),
                "osversion" => await _osVersionRepository.GetMostRecentByComputerNameAsync(computerName),
                "installedprograms" => await _installedProgramsRepository.GetMostRecentByComputerNameAsync(computerName),
                _ => null,
            };

            return info != null
                ? new ServiceResultModel<object>(
                    success: new SuccessServiceResult<object>(info, DateTime.UtcNow, computerName)
                    )
                : new ServiceResultModel<object>(
                    error: new ErrorServiceResult($"Não foi possível obter informações do tipo {infoType}.", DateTime.UtcNow, computerName)
                    );
        }


    }
}