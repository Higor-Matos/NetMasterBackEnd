// NetMaster.Services/Implementations/Hardware/HardwareInfoService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces;

namespace NetMaster.Services.Implementations.Hardware
{
    public abstract class HardwareInfoService<T> : BaseService where T : class
    {
        protected readonly IHardwareRepository<T> _hardwareRepository;
        protected readonly ILocalHardwareRepository<T> _localHardwareRepository;

        public HardwareInfoService(IHardwareRepository<T> hardwareRepository, ILocalHardwareRepository<T> localHardwareRepository)
        {
            _hardwareRepository = hardwareRepository;
            _localHardwareRepository = localHardwareRepository;
        }

        public async Task<ServiceResultModel<T>> SaveLocalHardwareInfoAsync(string ip)
        {
            RepositoryResultModel<T> localHardwareInfoResult = await _localHardwareRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            if (localHardwareInfoResult.SuccessResult != null)
            {
                await _hardwareRepository.InsertAsync(localHardwareInfoResult.SuccessResult.Result);
                SuccessServiceResult<T> successResult = new(localHardwareInfoResult.SuccessResult.Result, DateTime.UtcNow, ip);
                return new ServiceResultModel<T>(successResult);
            }
            else if (localHardwareInfoResult.ErrorResult != null)
            {
                ErrorServiceResult errorResult = new(localHardwareInfoResult.ErrorResult.Exception.Message, DateTime.UtcNow, ip);
                return new ServiceResultModel<T>(error: errorResult);
            }
            else
            {
                ErrorServiceResult errorResult = new($"Failed to get local hardware info.", DateTime.UtcNow, ip);
                return new ServiceResultModel<T>(error: errorResult);
            }
        }

        public async Task<ServiceResultModel<T>> GetHardwareInfoByComputerNameAsync(string computerName)
        {
            T hardwareInfo = await _hardwareRepository.GetByComputerNameAsync(computerName);
            SuccessServiceResult<T> successResult = new(hardwareInfo, DateTime.UtcNow, computerName);
            return new ServiceResultModel<T>(successResult);
        }
    }
}
