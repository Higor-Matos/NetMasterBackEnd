// NetMaster.Services/Interfaces/BaseCommands/ICommandRunner.cs
using NetMaster.Common;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Domain.Models.Results.Service;

namespace NetMaster.Services.Interfaces.Base
{
    [AutoDI]
    public interface ICommandRunner
    {
        ServiceResultModel<T> Run<T>(RepositoryResultModel<T> result) where T : class;
    }
}
