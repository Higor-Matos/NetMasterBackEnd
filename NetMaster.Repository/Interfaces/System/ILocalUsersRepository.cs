// NetMaster.Repository/Interfaces/ILocalUsersRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface ILocalUsersRepository : ILocalSystemRepository<UsersInfoDataModel>
    {
        Task<RepositoryResultModel<UsersInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param);
    }
}