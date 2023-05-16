// NetMaster.Services/Interfaces/BaseCommands/IBaseService.cs
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.BaseCommands
{
    public interface IBaseService
    {
        ServiceResultModel<T> RunCommand<T>(RepositoryResultModel<T> result) where T : class;
        RepositoryResultModel<object> ConvertResult(RepositoryResultModel<string> result);
    }
}