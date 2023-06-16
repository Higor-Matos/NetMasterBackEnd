// NetMaster.Services/Implementations/Software/FirefoxInstallerService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Repository.Interfaces.Software;
using NetMaster.Services.Implementations.Base;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.Software;

namespace NetMaster.Services.Implementations.Software
{
    public class FirefoxInstallerService : BaseService, IFirefoxInstallerService
    {
        private readonly IFirefoxInstallationRepository _installFirefoxRepository;

        public FirefoxInstallerService(ICommandRunner commandRunner, IResultConverter resultConverter, IFirefoxInstallationRepository installFirefoxRepository) : base(commandRunner, resultConverter)
        {
            _installFirefoxRepository = installFirefoxRepository;
        }

        public async Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip, string softwareName)
        {
            RepositoryResultModel<string> resultRep = await _installFirefoxRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}
