using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository;
using NetMaster.Repository.Local.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetMaster.Services
{
    public class SoftwareService : BaseService, ISoftwareService
    {
        private readonly Dictionary<string, IRepository> _softwareRepositories;

        public SoftwareService()
        {
            _softwareRepositories = new Dictionary<string, IRepository>
            {
                { "adobereader", new InstallAdobeReaderRepository() },
                { "firefox", new InstallFirefoxRepository() },
                { "googlechrome", new InstallGoogleChromeRepository() },
                { "office365", new InstallOffice365Repository() },
                { "vlc", new InstallVlcRepository() },
                { "winrar", new InstallWinrarRepository() },
            };
        }

        public async Task<ServiceResultModel<object>> InstallSoftwareCommand(string ip, string software)
        {
            software = software.ToLower();
            if (!_softwareRepositories.ContainsKey(software))
            {
                return ServiceResultModel<object>.Fail($"Software '{software}' not supported.");
            }

            IRepository repository = _softwareRepositories[software];
            RepositoryResultModel<string> resultRep = await repository.ExecCommand(new RepositoryPowerShellParamDataModel(ip));
            return RunCommand(ConvertResult(resultRep));
        }
    }
}
