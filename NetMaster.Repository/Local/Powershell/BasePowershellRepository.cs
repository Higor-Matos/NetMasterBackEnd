using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

public abstract class BasePowershellRepository
{
    private readonly CredentialProviderRepository credentialProvider;

    protected BasePowershellRepository()
    {
        this.credentialProvider = new CredentialProviderRepository();
    }

    protected async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param, string command, string? parameters = null)
    {
        PSCredential credential = credentialProvider.GetCredential();
        WSManConnectionInfo wsManConnectionInfo = new()
        {
            ComputerName = param.Ip,
            Credential = credential
        };

        return await PowershellRunNetworkRepository.RunCommandInSpace(wsManConnectionInfo, command, parameters);
    }
}