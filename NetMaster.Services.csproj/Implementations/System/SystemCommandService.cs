// NetMaster.Services/Implementation/System/SystemCommandService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Implementation.System;
namespace NetMaster.Services.Implementation.System
{
    public class SystemCommandService
    {
        private readonly ShutdownPcRepository _shutdownPcConectorRepository;
        private readonly RestartPcRepository _restartPcConectorRepository;

        public SystemCommandService(
            ShutdownPcRepository shutdownPcConectorRepository,
            RestartPcRepository restartPcConectorRepository
        )
        {
            _shutdownPcConectorRepository = shutdownPcConectorRepository;
            _restartPcConectorRepository = restartPcConectorRepository;
        }

        public async Task<ServiceResultModel<string>> ShutdownPcComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await _shutdownPcConectorRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return ConvertResult(resultRep);
        }

        public async Task<ServiceResultModel<string>> RestartPcComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await _restartPcConectorRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return ConvertResult(resultRep);
        }

        private ServiceResultModel<T> ConvertResult<T>(RepositoryResultModel<T> repositoryResult) where T : class
        {
            return repositoryResult.SuccessResult != null
                ? new ServiceResultModel<T>(
                    success: new SuccessServiceResult<T>(repositoryResult.Data, DateTime.UtcNow, repositoryResult.Ip)
                )
                : new ServiceResultModel<T>(
                    error: new ErrorServiceResult(repositoryResult.ErrorResult.Message, DateTime.UtcNow, repositoryResult.Ip)
                );
        }
    }
}