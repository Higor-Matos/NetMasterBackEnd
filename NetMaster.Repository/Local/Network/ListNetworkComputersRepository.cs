using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell;

namespace NetMaster.Repository.Local.Network
{
    public class ListNetworkComputersRepository : BasePowershellRepository
    {
        private static readonly string command = "powershell.exe";
        private static readonly string args = "-Command Get-WmiObject Win32_ComputerSystem | Select-Object Name";

        public override async Task<RepositoryResultModel> ExecCommand(RepositoryPowerShellParamModel param)
        {
            return await RunCommand(param, command, args);
        }
    }
}
