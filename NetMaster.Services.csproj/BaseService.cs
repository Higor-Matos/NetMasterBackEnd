using NetMaster.Domain.Models.Results;
using System;

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
                return new ServiceResultModel<T>(success: new SuccessServiceResult<T>(result.SuccessResult.Result, timestamp, computerName));
            }
            else
            {
                string msgError = result.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                return new ServiceResultModel<T>(error: new ErrorServiceResult(msgError, timestamp, computerName));
            }
        }

        protected RepositoryResultModel<object> ConvertResult(RepositoryResultModel<string> result)
        {
            return result.SuccessResult != null
                ? new RepositoryResultModel<object>(new SuccessRepositoryResult<object>(result.SuccessResult.Result), result.ErrorResult)
                : new RepositoryResultModel<object>(null, result.ErrorResult);
        }
    }
}
