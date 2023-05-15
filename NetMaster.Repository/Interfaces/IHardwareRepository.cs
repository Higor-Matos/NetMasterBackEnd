// NetMaster.Repository.Interfaces/IHardwareRepository.cs
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces
{
    public interface IHardwareRepository<T> : IBaseMongoRepository<T> where T : class
    {
        Task<RepositoryResultModel<T>> GetMostRecentByComputerNameAsync(string computerName);
    }
}
