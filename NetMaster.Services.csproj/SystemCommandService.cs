using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.System;

namespace NetMaster.Services
{
    public class SystemCommandService : BaseService
    {
        private readonly ShutdownPcRepository _shutdownPcRepository;
        private readonly RestartPcRepository _restartPcRepository;

        public SystemCommandService(ShutdownPcRepository shutdownPcRepository, RestartPcRepository restartPcRepository)
        {
            _shutdownPcRepository = shutdownPcRepository;
            _restartPcRepository = restartPcRepository;
        }

        public async Task<ServiceResultModel<object>> ShutdownPcComandAsync(string ip)
        {
            RepositoryResultModel<string> resultRep = await _shutdownPcRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }

        public async Task<ServiceResultModel<object>> RestartPcComandAsync(string ip)
        {
            RepositoryResultModel<string> resultRep = await _restartPcRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}
