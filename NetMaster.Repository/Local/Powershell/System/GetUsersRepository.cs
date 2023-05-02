using NetMaster.Domain.Models;
using NetMaster.Domain.Models.Results;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace NetMaster.Repository.Local.Powershell.System
{
    public class GetUsersRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = @"
                $computer = '" + param.Ip + @"'
                $computerName = (Get-WmiObject -Class Win32_ComputerSystem -ComputerName $computer).Name
                $users = Get-LocalUser | Where-Object { $_.Enabled -eq 'True' } | Select-Object Name, @{
                    Name='Group'; Expression={ (Get-LocalGroup -ComputerName $computer -Member $_).Name }
                }, @{
                    Name='IsAdmin'; Expression={ (Get-LocalGroup -ComputerName $computer -Member $_).Name -contains 'Administrators' }
                }, @{
                    Name='PSComputerName'; Expression={ $computerName }
                }
                $result = @{ 'PSComputerName' = $computerName; 'Users' = $users }
                $result | ConvertTo-Json -Compress
            ";


            string parameters = "";
            return await base.ExecCommand<string>(param, command, jsonOutput => jsonOutput, parameters);
        }
    }
}
