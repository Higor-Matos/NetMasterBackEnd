// NetMaster.Repository/Interfaces/IUsersRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.DataModels;

namespace NetMaster.Repository.Interfaces.System
{
    [AutoDI]
    public interface IUsersRepository : ISystemRepository<UsersInfoDataModel>
    {
    }
}