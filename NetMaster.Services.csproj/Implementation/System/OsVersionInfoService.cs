// NetMaster.Services/Implementation/System/OsVersionInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Domain.Models;
using NetMaster.Repository.Implementation.System;
using NetMaster.Repository.Interfaces.BaseCommand;
using NetMaster.Repository.Interfaces.System;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.BaseCommands;
using NetMaster.Services.Interfaces.System;

namespace NetMaster.Services.Implementation.System
{
    public class OsVersionInfoService : BaseService, IOsVersionInfoService
    {
        private readonly IBaseRepository<OSVersionInfoDataModel> _repository;
        private readonly LocalOsVersionRepository _localRepository;

        public OsVersionInfoService(
            IBaseRepository<OSVersionInfoDataModel> repository,
            LocalOsVersionRepository localRepository,
            ICommandRunner commandRunner,
            IResultConverter resultConverter
        ) : base(commandRunner, resultConverter)
        {
            _repository = repository;
            _localRepository = localRepository;
        }

        public async Task SaveLocalSystemInfoAsync(string ip)
        {
            RepositoryResultModel<OSVersionInfoDataModel> localInfoResult = await _localRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            if (localInfoResult.SuccessResult != null)
            {
                await _repository.InsertAsync(localInfoResult.SuccessResult.Result);
            }
        }

        public async Task<ServiceResultModel<OSVersionInfoDataModel>> GetSystemInfo(string ip)
        {
            OSVersionInfoDataModel info = await _repository.GetByComputerNameAsync(ip);
            return CreateServiceResult(info, "Não foi possível obter informações da versão do sistema operacional.", ip);
        }
    }
}