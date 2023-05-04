using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell.Hardware;
using System.Text.Json;

namespace NetMaster.Services.Powershell
{
    public class HardwareService : BaseService
    {
        private readonly GetRamRepository getRamUsageRep = new();
        private readonly GetStorageRepository getStorageRep = new();

        public async Task<ServiceResultModel<RamInfoModel>> GetRam(string ip)
        {
            RepositoryResultModel<RamInfoModel> resultRep = await getRamUsageRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel<StorageInfoModel>> GetStorage(string ip)
        {
            RepositoryResultModel<StorageInfoModel> resultRep = await getStorageRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

    }
}
