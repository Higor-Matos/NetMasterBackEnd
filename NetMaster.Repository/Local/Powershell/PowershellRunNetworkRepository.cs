using NetMaster.Domain.Models.Results;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

public class PowershellRunNetworkRepository
{
    public static async Task<RepositoryResultModel<T>> RunCommandInSpace<T>(
        WSManConnectionInfo wsManConnectionInfo,
        string command,
        Func<string, T> convertOutput,
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
            var convertedResult = convertOutput(returnResult);

            return new RepositoryResultModel<T>(success: new SuccessRepositoryResult<T>(convertedResult));


        }
        catch (Exception e)
        {
            return new RepositoryResultModel<T>(error: new ErrorRepositoryResult(e));
        }
        finally
        {
            runSpace.Close();
        }
    }
}