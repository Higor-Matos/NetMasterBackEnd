// NetMaster.Services/Implementations/Software/FirefoxInstallerService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.Software;
using NetMaster.Repository.Implementation.Software;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.BaseCommands;
using NetMaster.Services.Interfaces.Software;

namespace NetMaster.Services.Implementations.Software
{
    public class FirefoxInstallerService : BaseService , IFirefoxInstallerService
    {
        private readonly IInstallFirefoxRepository _installFirefoxRepository;

        public FirefoxInstallerService(ICommandRunner commandRunner, IResultConverter resultConverter, IInstallFirefoxRepository installFirefoxRepository) : base(commandRunner, resultConverter)
        {
            _installFirefoxRepository = installFirefoxRepository;
        }

        public async Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip)
        {
            RepositoryResultModel<string> resultRep = await _installFirefoxRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}
