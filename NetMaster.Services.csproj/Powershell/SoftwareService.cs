using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell.Software.Installers;

namespace NetMaster.Services.Powershell
{
    public class SoftwareService
    {

        private readonly InstallFirefoxRepository installFirefoxRep = new();
        private readonly InstallVlcRepository installVlcRep = new();
        private readonly InstallWinrarRepository installWinrarRep = new();
        private readonly InstallGoogleChromeRepository installGoogleChromeRep = new();
        private readonly InstallOffice365Repository installOffice365Rep = new();
        private readonly InstallAdobeReaderRepository installAdobeReaderRep = new();


        public async Task<ServiceResultModel<object>> InstallAdobeReaderComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await installAdobeReaderRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }

        public async Task<ServiceResultModel<object>> InstallFirefoxComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await installFirefoxRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));

        }

        public async Task<ServiceResultModel<object>> InstallGoogleChromeComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await installGoogleChromeRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));

        }

        public async Task<ServiceResultModel<object>> InstallOffice365Comand(string ip)
        {
            RepositoryResultModel<string> resultRep = await installOffice365Rep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));

        }

        public async Task<ServiceResultModel<object>> InstallVlcComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await installVlcRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));

        }

        public async Task<ServiceResultModel<object>> InstallWinrarComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await installWinrarRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));

        }

        private static ServiceResultModel<T> RunCommand<T>(RepositoryResultModel<T> result)
        {
            DateTime timestamp = DateTime.UtcNow;
            string computerName = Environment.MachineName;

            if (result.SuccessResult != null)
            {
                return new ServiceResultModel<T>(success: new SuccessServiceResult<T>(result.SuccessResult.Result, timestamp, computerName));
            }
            else
            {
                string msgError = result.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                return new ServiceResultModel<T>(error: new ErrorServiceResult(msgError, timestamp, computerName));
            }
        }

        private static RepositoryResultModel<object> ConvertResult(RepositoryResultModel<string> result)
        {
            return result.SuccessResult != null
                ? new RepositoryResultModel<object>(new SuccessRepositoryResult<object>(result.SuccessResult.Result), result.ErrorResult)
                : new RepositoryResultModel<object>(null, result.ErrorResult);
        }


    }
}
