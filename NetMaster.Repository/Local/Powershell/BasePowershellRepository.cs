using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;

namespace NetMaster.Repository.Local.Powershell
{
    public abstract class BasePowershellRepository
    {
        private readonly SecureString secureString = new();

        // depois passar esses dados para o "appsettings.json"
        private readonly static string username = @"192.168.100.10\Higor";
        private readonly static string password = "2210";

        public BasePowershellRepository()
        {
            SetSecuryString();
        }

        public abstract Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param);

        protected async Task<RepositoryResultModel> RunCommand(
            RepositoryPowerShellParamModel param,

            string comandPowershell,
            string remoteComputerName,
            string? comandParameterPowershell = null
        )
        {
            PSCredential credential = new(username, secureString);
            WSManConnectionInfo wsManConnectionInfo = new()
            {
                ComputerName = param.Ip,
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

        private async Task<RepositoryResultModel> RunCommandInSpace(
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

                powerShell.AddCommand(command).AddParameter($"\n {parameters ?? string.Empty}");

                var commandResult = await powerShell.InvokeAsync();
                var returnResult = string.Join(Environment.NewLine, commandResult.Select(c => c.ToString()).ToArray());


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
}