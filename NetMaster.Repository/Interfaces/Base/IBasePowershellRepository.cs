// NetMaster.Repository.Interfaces/IBasePowershellRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.Base
{
    [AutoDI]
    public interface IBasePowershellRepository
    {
        Task<RepositoryResultModel<T>> ExecCommand<T>(RepositoryPowerShellParamModel param, string command, Func<string, T> convertOutput, Dictionary<string, object>? parameters = null);
    }
}
