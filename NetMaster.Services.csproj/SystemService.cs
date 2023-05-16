// NetMaster.Services/SystemService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Services
{
    public class SystemService
    {
        private readonly ISystemInfoService<ChocolateyInfoDataModel> _chocolateyService;
        private readonly ISystemInfoService<UsersInfoDataModel> _usersService;
        private readonly ISystemInfoService<OSVersionInfoDataModel> _osVersionService;
        private readonly ISystemInfoService<InstalledProgramsResponseModel> _installedProgramsService;

        public SystemService(
            ISystemInfoService<ChocolateyInfoDataModel> chocolateyService,
            ISystemInfoService<UsersInfoDataModel> usersService,
            ISystemInfoService<OSVersionInfoDataModel> osVersionService,
            ISystemInfoService<InstalledProgramsResponseModel> installedProgramsService
        )
        {
            _chocolateyService = chocolateyService;
            _usersService = usersService;
            _osVersionService = osVersionService;
            _installedProgramsService = installedProgramsService;
        }

        public async Task SaveLocalSystemInfoAsync(string ip)
        {
            await _chocolateyService.SaveLocalSystemInfoAsync(ip);
            await _usersService.SaveLocalSystemInfoAsync(ip);
            await _osVersionService.SaveLocalSystemInfoAsync(ip);
            await _installedProgramsService.SaveLocalSystemInfoAsync(ip);
        }

        public async Task<ServiceResultModel<ChocolateyInfoDataModel>> VerifyChocolateyComand(string ip)
        {
            return await _chocolateyService.GetSystemInfo(ip);
        }

        public async Task<ServiceResultModel<UsersInfoDataModel>> GetUsers(string ip)
        {
            return await _usersService.GetSystemInfo(ip);
        }

        public async Task<ServiceResultModel<OSVersionInfoDataModel>> GetOsVersion(string ip)
        {
            return await _osVersionService.GetSystemInfo(ip);
        }

        public async Task<ServiceResultModel<InstalledProgramsResponseModel>> GetInstalledPrograms(string ip)
        {
            return await _installedProgramsService.GetSystemInfo(ip);
        }
    }
}
