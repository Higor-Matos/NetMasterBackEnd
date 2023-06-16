using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Interfaces.Powershell;
using Newtonsoft.Json;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace NetMaster.Repository.Implementations.Powershell
{
    public abstract class BasePowershellRepository : IBasePowershellRepository
    {
        private readonly CredentialProviderRepository credentialProvider;

        protected BasePowershellRepository()
        {
            credentialProvider = new CredentialProviderRepository();
        }

        public async Task<RepositoryResultModel<T>> ExecCommand<T>(RepositoryPowerShellParamModel param, string command, Func<string, T> convertOutput, Dictionary<string, object>? parameters = null)
        {
            PSCredential? credential = credentialProvider.GetCredential();
            WSManConnectionInfo wsManConnectionInfo = new()
            {
                ComputerName = param.Ip,
                Credential = credential ?? throw new InvalidOperationException("Credential is null.")
            };

            return await PowershellRunNetworkRepository.RunCommandInSpace(wsManConnectionInfo, command, convertOutput, parameters);
        }

        protected T ConvertOutput<T>(string jsonOutput, string ipAddress) where T : BaseInfoDataModel
        {
            T result = JsonConvert.DeserializeObject<T>(jsonOutput)!;
            result.IpAddress = ipAddress;

            result.Timestamp = DateTime.UtcNow;
            return result;
        }

    }
}