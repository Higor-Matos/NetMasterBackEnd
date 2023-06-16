// NetMaster.Services/Implementations/Software/VlcInstallerService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Repository.Interfaces.Software;
using NetMaster.Services.Implementations.Base;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.Software;

namespace NetMaster.Services.Implementations.Software
{
    public class VlcInstallerService : BaseService, IVlcInstallerService
    {
        private readonly IVlcInstallationRepository _installVlcRepository;

        public VlcInstallerService(ICommandRunner commandRunner, IResultConverter resultConverter, IVlcInstallationRepository installVlcRepository)
        : base(commandRunner, resultConverter)
        {
            _installVlcRepository = installVlcRepository;
        }

        public async Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip, string softwareName)
        {
            RepositoryResultModel<string> resultRep = await _installVlcRepository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}
