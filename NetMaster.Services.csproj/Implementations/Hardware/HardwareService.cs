// NetMaster.Services/Implementations/Hardware//HardwareService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.BaseCommands;
using NetMaster.Services.Interfaces.Hardware;

namespace NetMaster.Services.Implementations.Hardware
{
    public class HardwareService : BaseService, IHardwareService
    {
        private readonly IRamInfoService _ramInfoService;
        private readonly IStorageInfoService _storageInfoService;

        public HardwareService(
            IRamInfoService ramInfoService,
            IStorageInfoService storageInfoService,
            ICommandRunner commandRunner,
            IResultConverter resultConverter
        ) : base(commandRunner, resultConverter)
        {
            _ramInfoService = ramInfoService;
            _storageInfoService = storageInfoService;
        }

        public async Task<ServiceResultModel<RamInfoDataModel>> GetRamInfoAsync(string computerName)
        {
            return await _ramInfoService.GetHardwareInfoByComputerNameAsync(computerName);
        }

        public async Task<ServiceResultModel<StorageInfoDataModel>> GetStorageInfoAsync(string computerName)
        {
            return await _storageInfoService.GetHardwareInfoByComputerNameAsync(computerName);
        }
    }
}
