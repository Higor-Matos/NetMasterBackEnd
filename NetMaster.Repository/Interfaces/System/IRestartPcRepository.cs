using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using System.Threading.Tasks;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface IRestartPcRepository
    {
        Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
