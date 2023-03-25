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

    public abstract Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param);

    protected async Task<RepositoryResultModel> RunCommand(
        RepositoryPowerShellParamModel param,
        string commandPowershell,
        string? commandParameterPowershell = null
    )
    {
        PSCredential credential = credentialProvider.GetCredential();
        WSManConnectionInfo wsManConnectionInfo = new()
        {
            ComputerName = param.Ip,
            Credential = credential
        };

        return await RunCommandInSpace(wsManConnectionInfo, commandPowershell, commandParameterPowershell);
    }

    private static async Task<RepositoryResultModel> RunCommandInSpace(
        WSManConnectionInfo wsManConnectionInfo,
        string command,
        string? parameters
    )
    {
        using Runspace runSpace = RunspaceFactory.CreateRunspace(wsManConnectionInfo);
        try
        {
            using PowerShell powerShell = PowerShell.Create();

            runSpace.Open();
            powerShell.Runspace = runSpace;

            powerShell.AddScript(command);

            if (!string.IsNullOrEmpty(parameters))
            {
                powerShell.AddParameter(parameters + "\n");
            }

            var commandResult = await powerShell.InvokeAsync();
            var returnResult = string.Join(Environment.NewLine, commandResult);

            return new RepositoryResultModel(success: new SuccessRepositoryResult(returnResult));
        }
        catch (Exception e)
        {
            return new RepositoryResultModel(error: new ErrorRepositoryResult(e));
        }
        finally
        {
            runSpace.Close();
        }
    }
}
