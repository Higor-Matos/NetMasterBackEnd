// NetMaster.Services/Interfaces/IStorageInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using System.Threading.Tasks;

namespace NetMaster.Services.Interfaces
{
    public interface IStorageInfoService
    {
        Task SaveLocalStorageInfoAsync(string ip);
        Task<ServiceResultModel<StorageInfoDataModel>> GetStorageInfoByComputerNameAsync(string computerName);
    }
}
