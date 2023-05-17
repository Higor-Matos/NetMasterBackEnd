using NetMaster.Common;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using System.Threading.Tasks;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface IRestartPcRepository
    {
        Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
