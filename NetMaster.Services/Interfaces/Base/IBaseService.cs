// NetMaster.Services/Interfaces/BaseCommands/IBaseService.cs
using NetMaster.Common;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Domain.Models.Results.Service;

namespace NetMaster.Services.Interfaces.Base
{
    [AutoDI]
    public interface IBaseService
    {
        ServiceResultModel<T> RunCommand<T>(RepositoryResultModel<T> result) where T : class;
        RepositoryResultModel<object> ConvertResult(RepositoryResultModel<string> result);
    }
}