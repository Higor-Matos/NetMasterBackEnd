using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell.Software.Installers;
using NetMaster.Repository.Local.Upload;

namespace NetMaster.Services.Powershell
{
    public class PowershellService
    {
        public object[] ListNetworkComputerComand()
        {
            var computersAndIPs = new object[]
            {
                new { Name = "Higor-PC", IP = "192.168.0.3" },
                new { Name = "Gustavo-PC", IP = "192.168.0.4" },
                new { Name = "Convidado-PC", IP = "192.168.0.10" },
            };

            return computersAndIPs;
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
