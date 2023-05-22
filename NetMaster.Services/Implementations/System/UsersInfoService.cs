// NetMaster.Services/Implementation/System/UsersInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Repository.Interfaces.System;
using NetMaster.Services.Implementations.System;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.System;
using System.Threading.Tasks;

namespace NetMaster.Services.Implementation.System
{
    public class UsersInfoService : SystemInfoService<UsersInfoDataModel>, IUsersInfoService
    {
        public UsersInfoService(
            ISystemRepository<UsersInfoDataModel> usersRepository,
            ILocalSystemRepository<UsersInfoDataModel> localUsersRepository,
            ICommandRunner commandRunner,
            IResultConverter resultConverter
        ) : base(usersRepository, localUsersRepository, commandRunner, resultConverter)
        {
        }

        public Task<ServiceResultModel<UsersInfoDataModel>> SaveLocalUsersInfoAsync(string ip)
        {
            return SaveLocalSystemInfoAsync(ip);
        }

        public Task<ServiceResultModel<UsersInfoDataModel>> GetUsersInfoByComputerNameAsync(string computerName)
        {
            return GetSystemInfoByComputerNameAsync(computerName);
        }
    }
}