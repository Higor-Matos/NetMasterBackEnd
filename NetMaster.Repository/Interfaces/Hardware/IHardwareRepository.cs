// NetMaster.Repository/Interfaces/IHardwareRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.Base;
using System.Threading.Tasks;

namespace NetMaster.Repository.Interfaces.Hardware
{
    [AutoDI]
    public interface IHardwareRepository<T> : IBaseMongoRepository<T> where T : BaseInfoDataModel
    {
        Task<RepositoryResultModel<T>> GetMostRecentByComputerNameAsync(string computerName);
    }
}
