// NetMaster.Services/Implementations/Software/Office365InstallerService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Repository.Interfaces.Software;
using NetMaster.Services.Implementations.Base;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.Software;

namespace NetMaster.Services.Implementations.Software
{
    public class Office365InstallerService : BaseService, IOffice365InstallerService
    {
        private readonly IOffice365InstallationRepository _installOffice365Repository;

        public Office365InstallerService(ICommandRunner commandRunner, IResultConverter resultConverter, IOffice365InstallationRepository installOffice365Repository)
            : base(commandRunner, resultConverter)
        {
            _installOffice365Repository = installOffice365Repository;
        }

        public async Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip, string softwareName)
        {
            RepositoryResultModel<string> resultRep = await _installOffice365Repository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}
