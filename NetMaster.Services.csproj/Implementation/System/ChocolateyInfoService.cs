// NetMaster.Services/Implementation/System/ChocolateyInfoService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.BaseCommand;
using NetMaster.Repository.Interfaces.System;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.BaseCommands;
using NetMaster.Services.Interfaces.System;

namespace NetMaster.Services.Implementation.System
{
    public class ChocolateyInfoService : BaseService, IChocolateyInfoService
    {
        private readonly IBaseRepository<ChocolateyInfoDataModel> _repository;
        private readonly LocalChocolateyRepository _localRepository;

        public ChocolateyInfoService(
            IBaseRepository<ChocolateyInfoDataModel> repository,
            LocalChocolateyRepository localRepository,
            ICommandRunner commandRunner,
            IResultConverter resultConverter
        ) : base(commandRunner, resultConverter)
        {
            _repository = repository;
            _localRepository = localRepository;
        }


        public async Task SaveLocalSystemInfoAsync(string ip)
        {
            RepositoryResultModel<ChocolateyInfoDataModel> localInfoResult = await _localRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            if (localInfoResult.SuccessResult != null)
            {
                ChocolateyInfoDataModel info = localInfoResult.SuccessResult.Result;
                if (!string.IsNullOrEmpty(info.ChocolateyVersion))
                {
                    await _repository.InsertAsync(info);
                }
            }
        }

        public async Task<ServiceResultModel<ChocolateyInfoDataModel>> GetSystemInfo(string ip)
        {
            ChocolateyInfoDataModel info = await _repository.GetByComputerNameAsync(ip);
            return CreateServiceResult(info, "Não foi possível verificar o comando Chocolatey.", ip);
        }


    }
}