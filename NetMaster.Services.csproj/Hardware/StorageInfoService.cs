// NetMaster.Services/Hardware/StorageInfoService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces;
using NetMaster.Services.Interfaces;

namespace NetMaster.Services.Hardware
{
    public class StorageInfoService : BaseService, IStorageInfoService
    {
        private readonly IStorageRepository _storageRepository;
        private readonly ILocalStorageRepository _localStorageRepository;

        public StorageInfoService(IStorageRepository storageRepository, ILocalStorageRepository localStorageRepository)
        {
            _storageRepository = storageRepository;
            _localStorageRepository = localStorageRepository;
        }

        public async Task SaveLocalStorageInfoAsync(string ip)
        {
            RepositoryResultModel<StorageInfoDataModel> localStorageInfoResult = await _localStorageRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            if (localStorageInfoResult.SuccessResult != null)
            {
                await _storageRepository.InsertAsync(localStorageInfoResult.SuccessResult.Result);
            }
        }
        public async Task<ServiceResultModel<StorageInfoDataModel>> GetStorageInfoByComputerNameAsync(string computerName)
        {
            StorageInfoDataModel storageInfo = await _storageRepository.GetByComputerNameAsync(computerName);
            SuccessServiceResult<StorageInfoDataModel> successResult = new(storageInfo, DateTime.UtcNow, computerName);
            return new ServiceResultModel<StorageInfoDataModel>(successResult);
        }

    }
}