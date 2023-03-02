using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Security;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace NetMaster.Repository.Local.Powershell
{
    public class BasePowershellRepository
    {
        private readonly SecureString passwordAdminRemoteComputerSecureString = new();

        private readonly WSManConnectionInfo connectionInfoRemoteComputerPowershell = new();

        protected async Task<string> RunCommand(string comandPowershell, string remoteComputerName, string? comandParameterPowershell = null)
        {
            try
            {
                string userNameAdminRemoteComputer = @"192.168.100.10\Higor";
                string passwordAdminRemoteComputer = "2210";

                foreach (Char c in passwordAdminRemoteComputer)
                {
                    passwordAdminRemoteComputerSecureString.AppendChar(c);
                }

                PSCredential credentialsAdmimRemoteComputer = new(userNameAdminRemoteComputer, passwordAdminRemoteComputerSecureString);

                connectionInfoRemoteComputerPowershell.ComputerName = remoteComputerName;

                connectionInfoRemoteComputerPowershell.Credential = credentialsAdmimRemoteComputer;

                Runspace runspaceRemoteComputerPowershell = RunspaceFactory.CreateRunspace(connectionInfoRemoteComputerPowershell);

                runspaceRemoteComputerPowershell.Open();

                string returnResultComandRemotePowershell;

                using (PowerShell codeToRunInPowerShellRemote = PowerShell.Create())
                {
                    codeToRunInPowerShellRemote.Runspace = runspaceRemoteComputerPowershell;

                    codeToRunInPowerShellRemote.AddCommand(comandPowershell).AddParameter(comandParameterPowershell + "\n");
              
                    var resultComandRemotePowershell = await codeToRunInPowerShellRemote.InvokeAsync();

                    StringBuilder commandOutputPowerShellRemote = new();

                    foreach (var x in resultComandRemotePowershell)
                    {
                        commandOutputPowerShellRemote.AppendLine(x.ToString());
                    }
                    returnResultComandRemotePowershell = commandOutputPowerShellRemote.ToString();
                }

                runspaceRemoteComputerPowershell.Close();

                return returnResultComandRemotePowershell;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}