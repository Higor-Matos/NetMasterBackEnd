// NetMaster.Repository/Interfaces/ILocalSystemRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface ILocalSystemRepository<T> where T : class
    {
        Task<RepositoryResultModel<T>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}