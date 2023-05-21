// NetMaster.Repository/Interfaces/ISystemRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Interfaces.Base;
using System.Threading.Tasks;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface ISystemRepository<T> : IBaseMongoRepository<T> where T : BaseInfoDataModel
    {
        Task<RepositoryResultModel<T>> GetMostRecentByComputerNameAsync(string computerName);
    }
}