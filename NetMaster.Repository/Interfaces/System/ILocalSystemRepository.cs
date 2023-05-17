// NetMaster.Repository/Interfaces/ILocalSystemRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface ILocalSystemRepository<T> where T : class
    {
        Task<RepositoryResultModel<T>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}