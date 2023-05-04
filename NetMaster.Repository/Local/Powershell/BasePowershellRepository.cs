using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell.Credentials;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text.Json;

namespace NetMaster.Repository.Local.Powershell
{
    public abstract class BasePowershellRepository
    {
        private readonly CredentialProviderRepository credentialProvider;

        protected BasePowershellRepository()
        {
            credentialProvider = new CredentialProviderRepository();
        }

        public async Task<RepositoryResultModel<T>> ExecCommand<T>(RepositoryPowerShellParamModel param, string command, Func<string, T> convertOutput, Dictionary<string, object>? parameters = null)
        {
            PSCredential credential = credentialProvider.GetCredential();
            WSManConnectionInfo wsManConnectionInfo = new()
            {
                ComputerName = param.Ip,
                Credential = credential
            };

            return await PowershellRunNetworkRepository.RunCommandInSpace(wsManConnectionInfo, command, convertOutput, parameters);
        }

        protected T ConvertOutput<T>(string jsonOutput, string ipAddress) where T : BaseInfoModel
        {
            T result = JsonSerializer.Deserialize<T>(jsonOutput);
            result.IpAddress = ipAddress;
            result.Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            return result;
        }

    }
}