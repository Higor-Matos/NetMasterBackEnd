using NetMaster.Domain.Models.Results;
using NetMaster.Domain.Models;
using NetMaster.Repository.Interfaces.Software;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.Software;

namespace NetMaster.Services.Implementations.Software
{
    public class AdobeReaderInstallerService : BaseService, IAdobeReaderInstallerService
    {
        private readonly IInstallAdobeReaderRepository _installAdobeReaderRepository;

        public AdobeReaderInstallerService(ICommandRunner commandRunner, IResultConverter resultConverter, IInstallAdobeReaderRepository installAdobeReaderRepository)
            : base(commandRunner, resultConverter)
        {
            _installAdobeReaderRepository = installAdobeReaderRepository;
        }

        public async Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip, string softwareName)
        {
            RepositoryResultModel<string> resultRep = await _installAdobeReaderRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}