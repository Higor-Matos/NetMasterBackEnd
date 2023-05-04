using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Hardware;
using System.Text.Json;

namespace NetMaster.Services
{
    public class HardwareService : BaseService
    {
        private readonly RamRepository getRamUsageRep = new();
        private readonly StorageRepository getStorageRep = new();

        public async Task<ServiceResultModel<RamInfoDataModel>> GetRam(string ip)
        {
            RepositoryResultModel<RamInfoDataModel> resultRep = await getRamUsageRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel<StorageInfoDataModel>> GetStorage(string ip)
        {
            RepositoryResultModel<StorageInfoDataModel> resultRep = await getStorageRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

    }
}
