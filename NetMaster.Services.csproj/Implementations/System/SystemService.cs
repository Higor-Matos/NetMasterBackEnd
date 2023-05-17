// NetMaster.Services/Implementation/System/SystemService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.System;
using System.Threading.Tasks;

namespace NetMaster.Services.Implementation.System
{
    public class SystemService : BaseService, ISystemService
    {
        private readonly IChocolateyInfoService _chocolateyInfoService;
        private readonly IUsersInfoService _usersInfoService;
        private readonly IOsVersionInfoService _osVersionInfoService;
        private readonly IInstalledProgramsInfoService _installedProgramsInfoService;

        public SystemService(
            IChocolateyInfoService chocolateyInfoService,
            IUsersInfoService usersInfoService,
            IOsVersionInfoService osVersionInfoService,
            IInstalledProgramsInfoService installedProgramsInfoService,
            ICommandRunner commandRunner,
            IResultConverter resultConverter
        ) : base(commandRunner, resultConverter)
        {
            _chocolateyInfoService = chocolateyInfoService;
            _usersInfoService = usersInfoService;
            _osVersionInfoService = osVersionInfoService;
            _installedProgramsInfoService = installedProgramsInfoService;
        }

        public Task<ServiceResultModel<ChocolateyInfoDataModel>> GetChocolateyInfoAsync(string computerName)
        {
            return _chocolateyInfoService.GetSystemInfoByComputerNameAsync(computerName);
        }

        public Task<ServiceResultModel<UsersInfoDataModel>> GetUsersInfoAsync(string computerName)
        {
            return _usersInfoService.GetSystemInfoByComputerNameAsync(computerName);
        }

        public Task<ServiceResultModel<OSVersionInfoDataModel>> GetOsVersionInfoAsync(string computerName)
        {
            return _osVersionInfoService.GetSystemInfoByComputerNameAsync(computerName);
        }

        public Task<ServiceResultModel<InstalledProgramsResponseModel>> GetInstalledProgramsInfoAsync(string computerName)
        {
            return _installedProgramsInfoService.GetSystemInfoByComputerNameAsync(computerName);
        }
    }
}