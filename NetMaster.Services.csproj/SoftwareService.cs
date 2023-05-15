// NetMaster.Services/SoftwareService.cs
using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Software;
using NetMaster.Services.Implementations.BaseCommands;
using NetMaster.Services.Interfaces.BaseCommands;

namespace NetMaster.Services
{
    public class SoftwareService : BaseService
    {

        private readonly InstallFirefoxRepository installFirefoxRep = new();
        private readonly InstallVlcRepository installVlcRep = new();
        private readonly InstallWinrarRepository installWinrarRep = new();
        private readonly InstallGoogleChromeRepository installGoogleChromeRep = new();
        private readonly InstallOffice365Repository installOffice365Rep = new();
        private readonly InstallAdobeReaderRepository installAdobeReaderRep = new();

        public SoftwareService(ICommandRunner commandRunner, IResultConverter resultConverter) : base(commandRunner, resultConverter)
        {
        }

        public async Task<ServiceResultModel<object>> InstallAdobeReaderComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await installAdobeReaderRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }

        public async Task<ServiceResultModel<object>> InstallFirefoxComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await installFirefoxRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));

        }

        public async Task<ServiceResultModel<object>> InstallGoogleChromeComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await installGoogleChromeRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));

        }

        public async Task<ServiceResultModel<object>> InstallOffice365Comand(string ip)
        {
            RepositoryResultModel<string> resultRep = await installOffice365Rep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));

        }

        public async Task<ServiceResultModel<object>> InstallVlcComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await installVlcRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));

        }

        public async Task<ServiceResultModel<object>> InstallWinrarComand(string ip)
        {
            RepositoryResultModel<string> resultRep = await installWinrarRep.ExecCommand(new RepositoryPowerShellParamModel(ip));
            return RunCommand(ConvertResult(resultRep));

        }
    }
}
