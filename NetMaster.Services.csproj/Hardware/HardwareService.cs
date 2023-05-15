//NetMaster.Services.Hardware/Hardware/HardwareService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces;
using NetMaster.Services.Interfaces;

namespace NetMaster.Services.Hardware
{
    public class HardwareService : BaseService, IHardwareService
    {
        private readonly IRamRepository _ramRepository;
        private readonly IStorageRepository _storageRepository;

        public HardwareService(
            IRamRepository ramRepository,
            IStorageRepository storageRepository
        )
        {
            _ramRepository = ramRepository;
            _storageRepository = storageRepository;
        }
        public async Task<ServiceResultModel<RamInfoDataModel>> GetRamInfoAsync(string computerName)
        {
            RamInfoDataModel ramInfo = await _ramRepository.GetMostRecentByComputerNameAsync(computerName);
            SuccessServiceResult<RamInfoDataModel> successResult = new(ramInfo, DateTime.UtcNow, computerName);
            return new ServiceResultModel<RamInfoDataModel>(successResult);
        }

        public async Task<ServiceResultModel<StorageInfoDataModel>> GetStorageInfoAsync(string computerName)
        {
            StorageInfoDataModel storageInfo = await _storageRepository.GetMostRecentByComputerNameAsync(computerName);
            SuccessServiceResult<StorageInfoDataModel> successResult = new(storageInfo, DateTime.UtcNow, computerName);
            return new ServiceResultModel<StorageInfoDataModel>(successResult);
        }

    }
}
