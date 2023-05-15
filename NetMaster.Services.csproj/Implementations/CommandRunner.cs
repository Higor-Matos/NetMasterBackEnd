﻿// NetMaster.Services/Implementations/CommandRunner.cs
using NetMaster.Domain.Models.Results;
using NetMaster.Services.Interfaces;

namespace NetMaster.Services.Implementations
{
    public class CommandRunner : ICommandRunner
    {
        public ServiceResultModel<T> Run<T>(RepositoryResultModel<T> result) where T : class
        {
            DateTime timestamp = DateTime.UtcNow;
            string computerName = Environment.MachineName;

            if (result.SuccessResult != null)
            {
                SuccessServiceResult<T> successResult = new(result.SuccessResult.Result, timestamp, computerName);
                return new ServiceResultModel<T>(success: successResult);
            }
            else
            {
                string msgError = result.ErrorResult?.Exception.Message ?? "Ocorreu um erro.";
                ErrorServiceResult errorResult = new(msgError, timestamp, computerName);
                return new ServiceResultModel<T>(error: errorResult);
            }
        }
    }
}
