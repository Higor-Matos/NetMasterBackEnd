using NetMaster.Domain.Models;
using NetMaster.Repository.Interfaces.Software;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.Software;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Domain.Models.DataModels;

namespace NetMaster.Services.Implementations.Software
{
    public class AdobeReaderInstallerService : BaseService, IAdobeReaderInstallerService
    {
        private readonly IAdobeReaderInstallationRepository _installAdobeReaderRepository;

        public AdobeReaderInstallerService(ICommandRunner commandRunner, IResultConverter resultConverter, IAdobeReaderInstallationRepository installAdobeReaderRepository)
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