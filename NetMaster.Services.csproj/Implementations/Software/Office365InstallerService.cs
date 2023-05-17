// NetMaster.Services/Implementations/Software/Office365InstallerService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Implementation.Software;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.Base;
using NetMaster.Services.Interfaces.Software;
using NetMaster.Repository.Interfaces.Software;

namespace NetMaster.Services.Implementations.Software
{
    public class Office365InstallerService : BaseService, IOffice365InstallerService
    {
        private readonly IInstallOffice365Repository _installOffice365Repository;

        public Office365InstallerService(ICommandRunner commandRunner, IResultConverter resultConverter, IInstallOffice365Repository installOffice365Repository)
            : base(commandRunner, resultConverter)
        {
            _installOffice365Repository = installOffice365Repository;
        }

        public async Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip)
        {
            RepositoryResultModel<string> resultRep = await _installOffice365Repository.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}
