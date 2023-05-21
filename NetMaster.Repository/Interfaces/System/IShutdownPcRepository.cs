using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using System.Threading.Tasks;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface IShutdownPcRepository
    {
        Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
