using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository;
using NetMaster.Repository.Local.System;
using NetMaster.Services;

public class SystemService : BaseService
{
    private readonly IBaseRepository<ChocolateyInfoDataModel> _chocolateyRepository;
    private readonly IBaseRepository<UsersInfoDataModel> _usersRepository;
    private readonly IBaseRepository<OSVersionInfoDataModel> _osVersionRepository;
    private readonly IBaseRepository<InstalledProgramsResponseModel> _installedProgramsRepository;
    private readonly ShutdownPcRepository shutdownPcConectorRepository = new();
    private readonly RestartPcRepository restartPcConectorRepository = new();

    public SystemService(
        IBaseRepository<ChocolateyInfoDataModel> chocolateyRepository,
        IBaseRepository<UsersInfoDataModel> usersRepository,
        IBaseRepository<OSVersionInfoDataModel> osVersionRepository,
        IBaseRepository<InstalledProgramsResponseModel> installedProgramsRepository)
    {
        _chocolateyRepository = chocolateyRepository;
        _usersRepository = usersRepository;
        _osVersionRepository = osVersionRepository;
        _installedProgramsRepository = installedProgramsRepository;
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
}
