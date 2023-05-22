// NetMaster.Services/Implementations/Software/GoogleChromeInstallerService.cs
using NetMaster.Domain.Models;
using NetMaster.Repository.Implementation.Software;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.Software;
using NetMaster.Repository.Interfaces.Software;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Domain.Models.DataModels;

namespace NetMaster.Services.Implementations.Software
{
    public class GoogleChromeInstallerService : BaseService, IGoogleChromeInstallerService
    {
        private readonly IGoogleChromeInstallationRepository _installGoogleChromeRepository;

        public GoogleChromeInstallerService(ICommandRunner commandRunner, IResultConverter resultConverter, IGoogleChromeInstallationRepository installGoogleChromeRepository)
            : base(commandRunner, resultConverter)
        {
            _installGoogleChromeRepository = installGoogleChromeRepository;
        }

        public async Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip, string softwareName)
        {
            RepositoryResultModel<string> resultRep = await _installGoogleChromeRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}
