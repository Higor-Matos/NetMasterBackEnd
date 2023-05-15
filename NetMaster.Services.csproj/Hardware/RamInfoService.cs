// NetMaster.Services/Hardware/RamInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces;
using NetMaster.Services.Interfaces;

namespace NetMaster.Services.Hardware
{
    public class RamInfoService : HardwareInfoService<RamInfoDataModel>, IRamInfoService
    {
        public RamInfoService(IRamRepository ramRepository, ILocalRamRepository localRamRepository)
            : base(ramRepository, localRamRepository) { }

        public async Task<ServiceResultModel<RamInfoDataModel>> SaveLocalRamInfoAsync(string ip)
        {
            return await SaveLocalHardwareInfoAsync(ip);
        }

        public async Task<ServiceResultModel<RamInfoDataModel>> GetRamInfoByComputerNameAsync(string computerName)
        {
            return await GetHardwareInfoByComputerNameAsync(computerName);
        }
    }
}
