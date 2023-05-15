// NetMaster.Repository.Interfaces/ILocalStorageRepository.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell;
using System.Threading.Tasks;

namespace NetMaster.Repository.Interfaces
{
    public interface ILocalStorageRepository : ILocalHardwareRepository<StorageInfoDataModel>, IBasePowershellRepository
    {
        Task<RepositoryResultModel<StorageInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
