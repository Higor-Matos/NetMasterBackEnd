using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using System.Text.Json;

namespace NetMaster.Repository.Local.Powershell.System
{
    public class UsersRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel<LocalUsersInfoModel>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = @"$users = Get-LocalUser | Where-Object { $_.Enabled -eq $True } | ForEach-Object {
                $user = $_
                [PSCustomObject]@{
                    Name = $user.Name
                }
            }
            $computerName = (Get-CimInstance -ClassName Win32_ComputerSystem).Name
            $result = @{
                'Users' = $users
                'PSComputerName' = $computerName
            }
            $result | ConvertTo-Json -Depth 2 -Compress
            ";

            return await base.ExecCommand(param, command, jsonOutput => ConvertOutput<LocalUsersInfoModel>(jsonOutput, param.Ip));
        }
    }
}
