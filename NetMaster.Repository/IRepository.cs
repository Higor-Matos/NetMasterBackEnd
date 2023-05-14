using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using System.Threading.Tasks;

namespace NetMaster.Repository
{
    public interface IRepository
    {
        Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamDataModel param);
    }
}
