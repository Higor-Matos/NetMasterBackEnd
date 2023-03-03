using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;

namespace NetMaster.Repository.Local.Powershell
{
    public class BasePowershellRepository
    {
        private readonly SecureString secureString = new();

        private readonly static string username = @"192.168.100.10\Higor";
        private readonly static string password = "2210";

        public BasePowershellRepository()
        {
            SetSecuryString();
        }

        protected async Task<string?> RunCommand(
            string comandPowershell,
            string remoteComputerName,
            string? comandParameterPowershell = null
        )
        {
            PSCredential credential = new(username, secureString);
            WSManConnectionInfo wsManConnectionInfo = new()
            {
                ComputerName = remoteComputerName,
                Credential = credential
            };

            return await RunCommandInSpace(wsManConnectionInfo, comandPowershell, comandParameterPowershell);
        }

        private void SetSecuryString()
        {
            foreach (char letter in password)
            {
                secureString.AppendChar(letter);
            }
        }

        private async Task<string?> RunCommandInSpace(
            WSManConnectionInfo wsManConnectionInfo,
            string command,
            string? parameters
        )
        {
            Runspace runSpace = RunspaceFactory.CreateRunspace(wsManConnectionInfo);
            try
            {
                using PowerShell powerShell = PowerShell.Create();

                runSpace.Open();
                powerShell.Runspace = runSpace;
                powerShell.AddCommand(command)
                    .AddParameter($"{parameters ?? string.Empty} \n");

                var commandResult = await powerShell.InvokeAsync();
                var returnResult = string.Join(Environment.NewLine, commandResult);


                return returnResult;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                runSpace.Close();
            }
        }

    }
}