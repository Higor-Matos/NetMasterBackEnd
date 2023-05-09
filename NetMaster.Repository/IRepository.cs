using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using System.Threading.Tasks;

namespace NetMaster.Repository
{
    public interface IRepository
    {
        Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
