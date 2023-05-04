using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Local.Powershell;
using System.Text.Json;

namespace NetMaster.Repository.Local.System
{
    public class UsersRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel<LocalUsersInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param)
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

            return await ExecCommand(param, command, jsonOutput => ConvertOutput<LocalUsersInfoDataModel>(jsonOutput, param.Ip));
        }
    }
}
