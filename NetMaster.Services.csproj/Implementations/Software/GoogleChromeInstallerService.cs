// NetMaster.Services/Implementations/Software/GoogleChromeInstallerService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Implementation.Software;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.Software;
using NetMaster.Repository.Interfaces.Software;

namespace NetMaster.Services.Implementations.Software
{
    public class GoogleChromeInstallerService : BaseService, IGoogleChromeInstallerService
    {
        private readonly IInstallGoogleChromeRepository _installGoogleChromeRepository;

        public GoogleChromeInstallerService(ICommandRunner commandRunner, IResultConverter resultConverter, IInstallGoogleChromeRepository installGoogleChromeRepository)
            : base(commandRunner, resultConverter)
        {
            _installGoogleChromeRepository = installGoogleChromeRepository;
        }

        public async Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip)
        {
            RepositoryResultModel<string> resultRep = await _installGoogleChromeRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}
