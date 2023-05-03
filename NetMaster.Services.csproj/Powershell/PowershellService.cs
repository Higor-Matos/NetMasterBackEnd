using NetMaster.Domain.Models.Results;

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

        private static ServiceResultModel<object> RunCommand(RepositoryResultModel<object> result)
        {
            DateTime timestamp = DateTime.UtcNow;
            string computerName = Environment.MachineName;

            if (result.SuccessResult != null)
            {
                return new ServiceResultModel<object>(success: new SuccessServiceResult<object>(result.SuccessResult.Result, timestamp, computerName));
            }
            else
            {
                string msgError = result.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                return new ServiceResultModel<object>(error: new ErrorServiceResult(msgError, timestamp, computerName));
            }
        }
    }
}
