// NetMaster.Repository.Interfaces/IBasePowershellRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;

namespace NetMaster.Repository.Interfaces.Base
{
    [AutoDI]
    public interface IBasePowershellRepository
    {
        Task<RepositoryResultModel<T>> ExecCommand<T>(RepositoryPowerShellParamModel param, string command, Func<string, T> convertOutput, Dictionary<string, object>? parameters = null);
    }
}
