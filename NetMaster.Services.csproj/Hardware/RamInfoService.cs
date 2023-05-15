//NetMaster.Services.Hardware/Hardware/RamInfoService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces;
using NetMaster.Services.Interfaces;

namespace NetMaster.Services.Hardware
{
    public class RamInfoService : BaseService, IRamInfoService
    {
        private readonly IRamRepository _ramRepository;
        private readonly ILocalRamRepository _localRamRepository;

        public RamInfoService(IRamRepository ramRepository, ILocalRamRepository localRamRepository)
        {
            _ramRepository = ramRepository;
            _localRamRepository = localRamRepository;
        }

        public async Task<ServiceResultModel<RamInfoDataModel>> SaveLocalRamInfoAsync(string ip)
        {
            RepositoryResultModel<RamInfoDataModel> localRamInfoResult = await _localRamRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            if (localRamInfoResult.SuccessResult != null)
            {
                await _ramRepository.InsertAsync(localRamInfoResult.SuccessResult.Result);
                var successResult = new SuccessServiceResult<RamInfoDataModel>(localRamInfoResult.SuccessResult.Result, DateTime.UtcNow, ip);
                return new ServiceResultModel<RamInfoDataModel>(successResult);
            }
            else if (localRamInfoResult.ErrorResult != null)
            {
                var errorResult = new ErrorServiceResult(localRamInfoResult.ErrorResult.Exception.Message, DateTime.UtcNow, ip);
                return new ServiceResultModel<RamInfoDataModel>(error: errorResult);
            }
            else
            {
                var errorResult = new ErrorServiceResult($"Failed to get local RAM info.", DateTime.UtcNow, ip);
                return new ServiceResultModel<RamInfoDataModel>(error: errorResult);
            }
        }



        public async Task<ServiceResultModel<RamInfoDataModel>> GetRamInfoAsync(string computerName)
        {
            RamInfoDataModel ramInfo = await _ramRepository.GetMostRecentByComputerNameAsync(computerName);
            var successResult = new SuccessServiceResult<RamInfoDataModel>(ramInfo, DateTime.UtcNow, computerName);
            return new ServiceResultModel<RamInfoDataModel>(successResult);
        }

        public async Task<IEnumerable<RamInfoDataModel>> GetRamInfosAsync()
        {
            return await _ramRepository.GetAllAsync();
        }

        public async Task<ServiceResultModel<RamInfoDataModel>> GetRamInfoByComputerNameAsync(string computerName)
        {
            RamInfoDataModel ramInfo = await _ramRepository.GetByComputerNameAsync(computerName);
            var successResult = new SuccessServiceResult<RamInfoDataModel>(ramInfo, DateTime.UtcNow, computerName);
            return new ServiceResultModel<RamInfoDataModel>(successResult);
        }
    }
}
