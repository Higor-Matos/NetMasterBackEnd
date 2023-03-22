using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Network;

namespace NetMaster.Services.Network
{
    public class NetworkServices
    {
        private readonly ListNetworkComputersRepository listNetworkComputersConectorRep = new();

        public async Task<ServiceResultModel> ListNetworkComputerComand(string domain)
        {
            RepositoryResultModel resultRep = await listNetworkComputersConectorRep.ExecCommand(new RepositoryPowerShellParamModel(domain));
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
