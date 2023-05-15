// NetMaster.Services.Interfaces/ICommandRunner.cs
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces
{
    public interface ICommandRunner
    {
        ServiceResultModel<T> Run<T>(RepositoryResultModel<T> result) where T : class;
    }
}
