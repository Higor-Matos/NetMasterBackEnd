// NetMaster.Services/Interfaces/BaseCommands/ICommandRunner.cs
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.BaseCommands
{
    public interface ICommandRunner
    {
        ServiceResultModel<T> Run<T>(RepositoryResultModel<T> result) where T : class;
    }
}
