// NetMaster.Services/Implementations/Software/VlcInstallerService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.Software;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.BaseCommands;
using NetMaster.Services.Interfaces.Software;

namespace NetMaster.Services.Implementations.Software
{
    public class VlcInstallerService : BaseService, IVlcInstallerService
    {
        private readonly IInstallVlcRepository _installVlcRepository;

        public VlcInstallerService(ICommandRunner commandRunner, IResultConverter resultConverter, IInstallVlcRepository installVlcRepository)
        : base(commandRunner, resultConverter)
        {
            _installVlcRepository = installVlcRepository;
        }

        public async Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip)
        {
            RepositoryResultModel<string> resultRep = await _installVlcRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}
