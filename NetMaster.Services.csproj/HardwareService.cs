// NetMaster.Service/HardwareService.cs
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
            RepositoryResultModel<RamInfoDataModel> localRamInfoResult = await _localRamRepository.ExecCommand(new RepositoryPowerShellParamDataModel(ip));
            if (localRamInfoResult.SuccessResult != null)
            {
                await _ramRepository.InsertAsync(localRamInfoResult.SuccessResult.Result);
            }
        }

        public async Task SaveLocalStorageInfoAsync(string ip)
        {
            RepositoryResultModel<StorageInfoDataModel> localStorageInfoResult = await _localStorageRepository.ExecCommand(new RepositoryPowerShellParamDataModel(ip));
            if (localStorageInfoResult.SuccessResult != null)
            {
                await _storageRepository.InsertAsync(localStorageInfoResult.SuccessResult.Result);
            }
        }

        public async Task<ServiceResultModel<object>> GetInfoAsync(string infoType, string computerName)
        {
            object? info = infoType.ToLowerInvariant() switch
            {
                "ram" => await _ramRepository.GetMostRecentByComputerNameAsync(computerName),
                "storage" => await _storageRepository.GetMostRecentByComputerNameAsync(computerName),
                _ => null,
            };

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
