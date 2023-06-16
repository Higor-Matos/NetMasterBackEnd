using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Interfaces.MongoDB;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface ISystemRepository<T> : IBaseMongoRepository<T> where T : BaseInfoDataModel
    {
        new Task<RepositoryResultModel<T>> GetMostRecentByComputerNameAsync(string computerName);
    }
}
