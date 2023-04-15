using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell;
using System.Net;

namespace NetMaster.Services.Powershell
{
    public class PowershellService
    {
        private readonly ShutdownPcRepository shutdownPcConectorRep = new();
        private readonly RestartPcRepository restartPcConectorRep = new();
        private readonly VerifyChocolateyRepository verifyChocolateyRep = new();
        private readonly InstallAdobeReaderRepository installAdobeReaderRep = new();

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