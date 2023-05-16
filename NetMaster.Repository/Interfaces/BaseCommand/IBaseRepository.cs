//NetMaster.Repository/Interfaces/IBaseRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.BaseCommand
{
    public interface IBaseRepository<T> where T : BaseInfoDataModel
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByComputerNameAsync(string computerName);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task<RepositoryResultModel<T>> GetMostRecentByComputerNameAsync(string computerName);
    }
}
