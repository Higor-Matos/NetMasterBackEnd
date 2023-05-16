// NetMaster.Repository.Interfaces/IBaseMongoRepository.cs

namespace NetMaster.Repository.Interfaces.MongoDB
{
    public interface IBaseMongoRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByComputerNameAsync(string computerName);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
