﻿using NetMaster.Domain.Models;
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
            RepositoryResultModel<string> resultRep = await getStorageRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            DateTime timestamp = DateTime.UtcNow;
            string computerName = Environment.MachineName;

            if (resultRep.SuccessResult != null)
            {
                StorageInfoModel storageInfo = JsonSerializer.Deserialize<StorageInfoModel>(resultRep.SuccessResult.Result);
                return new ServiceResultModel<StorageInfoModel>(success: new SuccessServiceResult<StorageInfoModel>(storageInfo, timestamp, computerName));
            }
            else
            {
                string msgError = resultRep.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                return new ServiceResultModel<StorageInfoModel>(error: new ErrorServiceResult(msgError, timestamp, computerName));
            }
        }

    }
}
