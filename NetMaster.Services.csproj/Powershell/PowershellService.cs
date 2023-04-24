using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell.Hardware;
using NetMaster.Repository.Local.Powershell.Software;
using NetMaster.Repository.Local.Powershell.Software.Installers;
using NetMaster.Repository.Local.Powershell.System;
using NetMaster.Repository.Local.Upload;


namespace NetMaster.Services.Powershell
{
    public class PowershellService
    {
        private readonly ShutdownPcRepository shutdownPcConectorRep = new();
        private readonly RestartPcRepository restartPcConectorRep = new();
        private readonly VerifyChocolateyRepository verifyChocolateyRep = new();
        private readonly GetRamRepository getRamUsageRepository = new();
        private readonly GetStorageRepository getStorageRep = new();
        private readonly GetUsersRepository getUsersRepository = new();
        private readonly GetOsVersionRepository getOsVersionRepository = new();
        private readonly GetInstalledProgramsRepository getInstalledProgramsRepository = new();
        private readonly InstallAdobeReaderRepository installAdobeReaderRep = new();
        private readonly InstallFirefoxRepository installFirefoxRep = new();
        private readonly InstallVlcRepository installVlcRep = new();
        private readonly InstallWinrarRepository installWinrarRep = new();
        private readonly InstallGoogleChromeRepository installGoogleChromeRep = new();
        private readonly InstallOffice365Repository installOffice365Rep = new();
        private readonly UploadFileRepository uploadFileRepository = new();


        public ServiceResultModel UploadFile(string fileName, byte[] fileData, string destinationFolder)
        {
            RepositoryResultModel resultRep = uploadFileRepository.UploadFile(fileName, fileData, destinationFolder);
            return RunCommand(resultRep);
        }



        public async Task<ServiceResultModel> GetUsers(string ip)
        {
            RepositoryResultModel resultRep = await getUsersRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel> GetOsVersion(string ip)
        {
            RepositoryResultModel resultRep = await getOsVersionRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel> GetInstalledPrograms(string ip)
        {
            RepositoryResultModel resultRep = await getInstalledProgramsRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel> getStorage(string ip)
        {
            RepositoryResultModel resultRep = await getStorageRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel> GetRamUsage(string ip)
        {
            RepositoryResultModel resultRep = await getRamUsageRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel> ShutdownPcComand(string ip)
        {
            RepositoryResultModel resultRep = await shutdownPcConectorRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

        public async Task<ServiceResultModel> RestartPcComand(string ip)
        {
            RepositoryResultModel resultRep = await restartPcConectorRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(resultRep);
        }

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

        public string[] ListNetworkComputerComand()
        {
            var computers = new string[] { "Higor-PC", "Gustavo-PC", "Convidado-PC" };
            var ips = new string[] { "192.168.0.3", "192.168.0.4", "192.168.0.10" };
            return computers;
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