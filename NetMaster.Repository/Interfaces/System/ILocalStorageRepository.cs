// NetMaster.Repository.Interfaces/ILocalStorageRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Implementation.Powershell;
using NetMaster.Repository.Interfaces.Base;
using NetMaster.Repository.Interfaces.Hardware;
using System.Threading.Tasks;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface ILocalStorageRepository : ILocalHardwareRepository<StorageInfoDataModel>, IBasePowershellRepository
    {
        Task<RepositoryResultModel<StorageInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
