// NetMaster.Repository.Interfaces/IHardwareRepository.cs
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.MongoDB;

namespace NetMaster.Repository.Interfaces.Hardware
{
    public interface IHardwareRepository<T> : IBaseMongoRepository<T> where T : class
    {
        Task<RepositoryResultModel<T>> GetMostRecentByComputerNameAsync(string computerName);
    }
}
