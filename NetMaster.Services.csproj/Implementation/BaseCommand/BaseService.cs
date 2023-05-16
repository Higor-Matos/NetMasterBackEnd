// NetMaster.Services/Implementations/BaseCommands/BaseService.cs
using NetMaster.Domain.Models.Results;
using NetMaster.Services.Interfaces.BaseCommands;

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
    }
}
