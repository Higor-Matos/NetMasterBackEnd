// NetMaster.Services/Implementation/System/InstalledProgramsInfoService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.Software;
using NetMaster.Repository.Interfaces.System;
using NetMaster.Services.Implementations.System;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.System;
using System.Threading.Tasks;

namespace NetMaster.Services.Implementation.System
{
    public class InstalledProgramsInfoService : SystemInfoService<InstalledProgramsResponseModel>, IInstalledProgramsInfoService
    {
        public InstalledProgramsInfoService(
            IInstalledProgramsRepository installedProgramsRepository,
            ILocalInstalledProgramsRepository localinstalledProgramsRepository,
            ICommandRunner commandRunner,
            IResultConverter resultConverter
        ) : base(installedProgramsRepository, localinstalledProgramsRepository, commandRunner, resultConverter)
        {
        }

        public Task<ServiceResultModel<InstalledProgramsResponseModel>> SaveLocalInstalledProgramsInfoAsync(string ip)
        {
            return SaveLocalSystemInfoAsync(ip);
        }

        public Task<ServiceResultModel<InstalledProgramsResponseModel>> GetInstalledProgramsByComputerNameAsync(string computerName)
        {
            return GetSystemInfoByComputerNameAsync(computerName);
        }
    }
}