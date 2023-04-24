using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell.Software;
using NetMaster.Repository.Local.Powershell.Software.Installers;

namespace NetMaster.Services.Powershell.PowershellServices
{
    public class SoftwareService
    {
       
        private readonly InstallFirefoxRepository installFirefoxRep = new();
        private readonly InstallVlcRepository installVlcRep = new();
        private readonly InstallWinrarRepository installWinrarRep = new();
        private readonly InstallGoogleChromeRepository installGoogleChromeRep = new();
        private readonly InstallOffice365Repository installOffice365Rep = new();
        private readonly VerifyChocolateyRepository verifyChocolateyRep = new();
        private readonly InstallAdobeReaderRepository installAdobeReaderRep = new();

        public async Task<ServiceResultModel> VerifyChocolateyComand(string ip)
        {
            RepositoryResultModel resultRep = await verifyChocolateyRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);

        }

        public async Task<ServiceResultModel> InstallAdobeReaderComand(string ip)
        {
            RepositoryResultModel resultRep = await installAdobeReaderRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);

        }

        public async Task<ServiceResultModel> InstallFirefoxComand(string ip)
        {
            RepositoryResultModel resultRep = await installFirefoxRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);

        }

        public async Task<ServiceResultModel> InstallGoogleChromeComand(string ip)
        {
            RepositoryResultModel resultRep = await installGoogleChromeRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);

        }

        public async Task<ServiceResultModel> InstallOffice365Comand(string ip)
        {
            RepositoryResultModel resultRep = await installOffice365Rep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);

        }

        public async Task<ServiceResultModel> InstallVlcComand(string ip)
        {
            RepositoryResultModel resultRep = await installVlcRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);

        }

        public async Task<ServiceResultModel> InstallWinrarComand(string ip)
        {
            RepositoryResultModel resultRep = await installWinrarRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
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
