// NetMaster.Repository.Interfaces/ILocalHardwareRepository.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces
{
    public interface ILocalHardwareRepository<T> where T : class
    {
        Task<RepositoryResultModel<T>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
