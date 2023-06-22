// NetMaster.Repository/Interfaces/IHardwareRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Interfaces.Base;

namespace NetMaster.Repository.Interfaces.Hardware
{
    [AutoDI]
    public interface IHardwareRepository<T> : IBaseMongoRepository<T> where T : BaseInfoDataModel
    {
        new Task<RepositoryResultModel<T>> GetMostRecentByComputerNameAsync(string computerName);
    }
}
