﻿using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell.Software.Installers;
using NetMaster.Repository.Local.Upload;


namespace NetMaster.Services.Powershell
{
    public class PowershellService
    {

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