using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Configuration;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;

namespace NetMaster.Repository.Local.Powershell
{
    public abstract class BasePowershellRepository
    {
        private readonly SecureString secureString = new();
        private readonly ConfigurationRepository configRep = new();
        public BasePowershellRepository()
        {
            SetSecuryString();
        }

        public abstract Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param);

        protected async Task<RepositoryResultModel> RunCommand(
            RepositoryPowerShellParamModel param,
            string comandPowershell,
            string? comandParameterPowershell = null
        )
        {
            string username = configRep.GetValue("Credentials:Username");
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
            string password = configRep.GetValue("Credentials:Password");
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

                powerShell.AddCommand(command).AddParameter($"{parameters ?? string.Empty} \n");

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
}