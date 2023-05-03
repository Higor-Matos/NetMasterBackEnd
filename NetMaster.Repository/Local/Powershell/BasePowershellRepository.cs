using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell.Credentials;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

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
}
