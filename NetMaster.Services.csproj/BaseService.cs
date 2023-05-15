// NetMaster.Services/BaseService.cs
using NetMaster.Domain.Models.Results;
using NetMaster.Services.Interfaces;

namespace NetMaster.Services
{
    public abstract class BaseService
    {
        private readonly ICommandRunner _commandRunner;
        private readonly IResultConverter _resultConverter;

        protected BaseService(ICommandRunner commandRunner, IResultConverter resultConverter)
        {
            _commandRunner = commandRunner;
            _resultConverter = resultConverter;
        }

        protected ServiceResultModel<T> RunCommand<T>(RepositoryResultModel<T> result) where T : class
        {
            return _commandRunner.Run<T>(result);
        }

        protected RepositoryResultModel<object> ConvertResult(RepositoryResultModel<string> result)
        {
            return _resultConverter.Convert(result);
        }
    }
}
