using NetMaster.Domain.Models.Results;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

public class PowershellRunNetworkRepository
{
    public static async Task<RepositoryResultModel<T>> RunCommandInSpace<T>(
        WSManConnectionInfo wsManConnectionInfo,
        string command,
        Func<string, T> convertOutput,
        Dictionary<string, object>? parameters = null
    )
    {
        using Runspace runSpace = RunspaceFactory.CreateRunspace(wsManConnectionInfo);
        try
        {
            using PowerShell powerShell = PowerShell.Create();

            runSpace.Open();
            powerShell.Runspace = runSpace;

            _ = powerShell.AddScript(command);

            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    _ = powerShell.AddParameter(parameter.Key, parameter.Value);
                }
            }

            PSDataCollection<PSObject> commandResult = await Task.Factory.FromAsync<PSDataCollection<PSObject>>(
                powerShell.BeginInvoke(),
                powerShell.EndInvoke);
            string returnResult = string.Join(Environment.NewLine, commandResult);
                T? convertedResult = convertOutput(returnResult);

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
