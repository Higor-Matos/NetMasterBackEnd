// NetMaster.Services/Implementations/Software/WinrarInstallerService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Repository.Interfaces.Software;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.Software;

namespace NetMaster.Services.Implementations.Software
{
    public class WinrarInstallerService : BaseService, IWinrarInstallerService
    {
        private readonly IWinrarInstallationRepository _installWinrarRepository;

        public WinrarInstallerService(ICommandRunner commandRunner, IResultConverter resultConverter, IWinrarInstallationRepository installWinrarRepository)
            : base(commandRunner, resultConverter)
        {
            _installWinrarRepository = installWinrarRepository;
        }

        public async Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip, string softwareName)
        {
            RepositoryResultModel<string> resultRep = await _installWinrarRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}
