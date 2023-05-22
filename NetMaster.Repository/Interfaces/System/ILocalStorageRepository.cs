using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Implementation.Powershell;
using NetMaster.Repository.Interfaces.Base;
using NetMaster.Repository.Interfaces.Hardware;
using System.Threading.Tasks;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface ILocalStorageRepository : ILocalHardwareRepository<StorageInfoDataModel>, IBasePowershellRepository
    {
        new Task<RepositoryResultModel<StorageInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}
