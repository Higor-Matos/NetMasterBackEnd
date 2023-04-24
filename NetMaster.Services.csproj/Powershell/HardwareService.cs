using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell.Hardware;

namespace NetMaster.Services.Powershell.PowershellServices
{
    public class HardwareService
    {
        private readonly GetRamRepository getRamUsageRep = new();
        private readonly GetStorageRepository getStorageRep = new();

        public async Task<ServiceResultModel> GetRam(string ip)
        {
            RepositoryResultModel resultRep = await getRamUsageRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel> GetStorage(string ip)
        {
            RepositoryResultModel resultRep = await getStorageRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        private static ServiceResultModel RunCommand(RepositoryResultModel result)
        {
            if (result.SuccessResult != null)
            {
                return new ServiceResultModel(success: new SuccessServiceResult(result.SuccessResult.Result));
            }
            else
            {
                string msgError = result.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                return new ServiceResultModel(error: new ErrorServiceResult(msgError));
            }
        }
    }
}
