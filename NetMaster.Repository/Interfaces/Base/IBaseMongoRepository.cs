// NetMaster.Repository/Interfaces/IBaseMongoRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetMaster.Repository.Interfaces.Base
{
    
    public interface IBaseMongoRepository<T> where T : BaseInfoDataModel
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByComputerNameAsync(string computerName);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task<RepositoryResultModel<T>> GetMostRecentByComputerNameAsync(string computerName);
    }
}