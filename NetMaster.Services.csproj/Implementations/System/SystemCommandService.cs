using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Repository.Interfaces.System;
using NetMaster.Services.Interfaces.System;

namespace NetMaster.Services.Implementations.System
{
    public class SystemCommandService : ISystemCommandService
    {
        private readonly IShutdownPcRepository _shutdownPcRepository;
        private readonly IRestartPcRepository _restartPcRepository;

        public SystemCommandService(
            IShutdownPcRepository shutdownPcRepository,
            IRestartPcRepository restartPcRepository
        )
        {
            _shutdownPcRepository = shutdownPcRepository;
            _restartPcRepository = restartPcRepository;
        }

        public async Task<ServiceResultModel<string>> ShutdownPcCommand(string ip)
        {
            RepositoryResultModel<string> repositoryResult = await _shutdownPcRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return ConvertResult(repositoryResult);
        }

        public async Task<ServiceResultModel<string>> RestartPcCommand(string ip)
        {
            RepositoryResultModel<string> repositoryResult = await _restartPcRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return ConvertResult(repositoryResult);
        }

        private ServiceResultModel<string> ConvertResult(RepositoryResultModel<string> repositoryResult)
        {
            if (repositoryResult.SuccessResult != null)
            {
                return new ServiceResultModel<string>(
                    success: new SuccessServiceResult<string>(repositoryResult.SuccessResult.Result, DateTime.UtcNow, repositoryResult.Ip)
                );
            }
            else
            {
                return repositoryResult.ErrorResult != null
                    ? new ServiceResultModel<string>(
                                    error: new ErrorServiceResult(repositoryResult.ErrorResult.Message, DateTime.UtcNow, repositoryResult.Ip)
                                )
                    : throw new InvalidOperationException("Invalid repository result. Must have either SuccessResult or ErrorResult.");
            }
        }
    }
}
