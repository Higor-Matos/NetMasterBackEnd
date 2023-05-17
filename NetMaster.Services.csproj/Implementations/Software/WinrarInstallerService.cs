// NetMaster.Services/Implementations/Software/WinrarInstallerService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.Software;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.Software;

namespace NetMaster.Services.Implementations.Software
{
    public class WinrarInstallerService : BaseService, IWinrarInstallerService
    {
        private readonly IInstallWinrarRepository _installWinrarRepository;

        public WinrarInstallerService(ICommandRunner commandRunner, IResultConverter resultConverter, IInstallWinrarRepository installWinrarRepository)
            : base(commandRunner, resultConverter)
        {
            _installWinrarRepository = installWinrarRepository;
        }

        public async Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip)
        {
            RepositoryResultModel<string> resultRep = await _installWinrarRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}
