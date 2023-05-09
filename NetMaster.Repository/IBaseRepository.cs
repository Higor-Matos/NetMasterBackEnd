using NetMaster.Domain.Models.DataModels;

namespace NetMaster.Repository
{
    public interface IBaseRepository<T> where T : BaseInfoDataModel
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByComputerNameAsync(string computerName);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> GetMostRecentByComputerNameAsync(string computerName);
    }

}