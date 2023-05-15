// NetMaster.Repository.Interfaces/IBasePowershellRepository.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces
{
    public interface IBasePowershellRepository
    {
        Task<RepositoryResultModel<T>> ExecCommand<T>(RepositoryPowerShellParamModel param, string command, Func<string, T> convertOutput, Dictionary<string, object>? parameters = null);
    }
}
