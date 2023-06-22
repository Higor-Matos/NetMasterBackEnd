// NetMaster.Services/Implementations/BaseCommands/BaseService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Services.Interfaces.Base;

namespace NetMaster.Services.Implementations.BaseCommands
{
    public abstract class BaseService : IBaseService
    {
        private readonly ICommandRunner _commandRunner;
        private readonly IResultConverter _resultConverter;

        protected BaseService(ICommandRunner commandRunner, IResultConverter resultConverter)
        {
            _commandRunner = commandRunner;
            _resultConverter = resultConverter;
        }

        public ServiceResultModel<T> RunCommand<T>(RepositoryResultModel<T> result) where T : class
        {
            return _commandRunner.Run(result);
        }

        public RepositoryResultModel<object> ConvertResult(RepositoryResultModel<string> result)
        {
            return _resultConverter.Convert(result);
        }

        protected ServiceResultModel<T> CreateServiceResult<T>(T data, string errorMessage, string ip) where T : BaseInfoDataModel
        {
            return data != null
                ? new ServiceResultModel<T>(
                    success: new SuccessServiceResult<T>(data, DateTime.UtcNow, ip)
                )
                : new ServiceResultModel<T>(
                    error: new ErrorServiceResult(errorMessage, DateTime.UtcNow, ip)
                );
        }
    }
}
