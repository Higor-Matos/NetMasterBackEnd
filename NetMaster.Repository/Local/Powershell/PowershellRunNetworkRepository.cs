using NetMaster.Domain.Models.Results;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Threading.Tasks;

public class PowershellRunNetworkRepository
{
    public static async Task<RepositoryResultModel> RunCommandInSpace(
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