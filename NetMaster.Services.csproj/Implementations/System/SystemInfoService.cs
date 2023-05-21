// NetMaster.Services/Implementations/System/SystemInfoService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Repository.Interfaces.System;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.Base;
using System.Threading.Tasks;

namespace NetMaster.Services.Implementations.System
{
    public abstract class SystemInfoService<T> : BaseService where T : BaseInfoDataModel
    {
        protected readonly ISystemRepository<T> _systemRepository;
        protected readonly ILocalSystemRepository<T> _localSystemRepository;

        public SystemInfoService(ISystemRepository<T> systemRepository, ILocalSystemRepository<T> localSystemRepository, ICommandRunner commandRunner, IResultConverter resultConverter) : base(commandRunner, resultConverter)
        {
            _systemRepository = systemRepository;
            _localSystemRepository = localSystemRepository;
        }
        public async Task<ServiceResultModel<T>> SaveLocalSystemInfoAsync(string ip)
        {
            RepositoryResultModel<T> localSystemInfoResult = await _localSystemRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            if (localSystemInfoResult.SuccessResult != null)
            {
                await _systemRepository.InsertAsync(localSystemInfoResult.SuccessResult.Result);
                SuccessServiceResult<T> successResult = new SuccessServiceResult<T>(localSystemInfoResult.SuccessResult.Result, DateTime.UtcNow, ip);
                return new ServiceResultModel<T>(successResult);
            }
            else if (localSystemInfoResult.ErrorResult != null)
            {
                ErrorServiceResult errorResult = new ErrorServiceResult(localSystemInfoResult.ErrorResult.Exception.Message, DateTime.UtcNow, ip);
                return new ServiceResultModel<T>(error: errorResult);
            }
            else
            {
                ErrorServiceResult errorResult = new ErrorServiceResult("Failed to get local system info.", DateTime.UtcNow, ip);
                return new ServiceResultModel<T>(error: errorResult);
            }
        }
        public async Task<ServiceResultModel<T>> GetSystemInfoByComputerNameAsync(string computerName)
        {
            T systemInfo = await _systemRepository.GetByComputerNameAsync(computerName);
            SuccessServiceResult<T> successResult = new SuccessServiceResult<T>(systemInfo, DateTime.UtcNow, computerName);
            return new ServiceResultModel<T>(successResult);
        }
    }
}