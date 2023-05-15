// NetMaster.Services/BaseService.cs
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services
{
    public abstract class BaseService
    {
        protected ServiceResultModel<T> RunCommand<T>(RepositoryResultModel<T> result) where T : class
        {
            DateTime timestamp = DateTime.UtcNow;
            string computerName = Environment.MachineName;

            if (result.SuccessResult != null)
            {
                var successResult = new SuccessServiceResult<T>(result.SuccessResult.Result, timestamp, computerName);
                return new ServiceResultModel<T>(success: successResult);
            }
            else
            {
                string msgError = result.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                var errorResult = new ErrorServiceResult(msgError, timestamp, computerName);
                return new ServiceResultModel<T>(error: errorResult);
            }
        }



        protected RepositoryResultModel<object> ConvertResult(RepositoryResultModel<string> result)
        {
            return result.SuccessResult != null
                ? new RepositoryResultModel<object>(data: result.SuccessResult.Result, success: true, error: result.ErrorResult)
                : new RepositoryResultModel<object>(success: false, error: result.ErrorResult);
        }

    }
}
