// NetMaster.Repository/Implementation/System/LocalUsersRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Implementation.Powershell;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Repository.Implementation.System
{
    public class LocalUsersRepository : BasePowershellRepository, ILocalUsersRepository
    {
        public async Task<RepositoryResultModel<UsersInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param)
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

            return await ExecCommand(param, command, jsonOutput => ConvertOutput<UsersInfoDataModel>(jsonOutput, param.Ip));
        }
    }
}