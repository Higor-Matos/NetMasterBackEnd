using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository;
using NetMaster.Repository.Local.Hardware;

namespace NetMaster.Services
{
    public class HardwareService : BaseService
    {
        private readonly IBaseRepository<RamInfoDataModel> _ramRepository;
        private readonly IBaseRepository<StorageInfoDataModel> _storageRepository;
        private readonly LocalRamRepository _localRamRepository;
        private readonly LocalStorageRepository _localStorageRepository;

        public HardwareService(
            IBaseRepository<RamInfoDataModel> ramRepository,
            IBaseRepository<StorageInfoDataModel> storageRepository,
            LocalRamRepository localRamRepository,
            LocalStorageRepository localStorageRepository)
        {
            _ramRepository = ramRepository;
            _storageRepository = storageRepository;
            _localRamRepository = localRamRepository;
            _localStorageRepository = localStorageRepository;
        }

        public async Task SaveLocalRamInfoAsync(string ip)
        {
            RepositoryResultModel<RamInfoDataModel> localRamInfoResult = await _localRamRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            if (localRamInfoResult.SuccessResult != null)
            {
                await _ramRepository.InsertAsync(localRamInfoResult.SuccessResult.Result);
            }
        }

        public async Task SaveLocalStorageInfoAsync(string ip)
        {
            RepositoryResultModel<StorageInfoDataModel> localStorageInfoResult = await _localStorageRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            if (localStorageInfoResult.SuccessResult != null)
            {
                await _storageRepository.InsertAsync(localStorageInfoResult.SuccessResult.Result);
            }
        }

        public async Task<ServiceResultModel<object>> GetInfoAsync(string infoType, string computerName)
        {
            object? info = null;

            switch (infoType.ToLower())
            {
                case "ram":
                    info = await _ramRepository.GetMostRecentByComputerNameAsync(computerName);
                    break;
                case "storage":
                    info = await _storageRepository.GetMostRecentByComputerNameAsync(computerName);
                    break;
            }

            return info != null
                ? new ServiceResultModel<object>(
                    success: new SuccessServiceResult<object>(info, DateTime.UtcNow, computerName)
                    )
                : new ServiceResultModel<object>(
                    error: new ErrorServiceResult($"Não foi possível obter informações do tipo {infoType}.", DateTime.UtcNow, computerName)
                    );
        }

        public async Task<IEnumerable<RamInfoDataModel>> GetRamInfosAsync()
        {
            return await _ramRepository.GetAllAsync();
        }

        public async Task<RamInfoDataModel> GetRamInfoByComputerNameAsync(string computerName)
        {
            return await _ramRepository.GetByComputerNameAsync(computerName);
        }
    }
}