using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;

namespace NetMaster.Repository.Interfaces.FileDistribution
{
    [AutoDI]
    public interface ISendFileRepository
    {
        Task<RepositoryResultModel<string>> SendFile(RepositoryPowerShellParamModel param, string filePath);
    }
}
