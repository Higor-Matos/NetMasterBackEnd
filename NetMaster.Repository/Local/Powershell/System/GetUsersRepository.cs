using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using System;
using System.Text.Json;

namespace NetMaster.Repository.Local.Powershell.System
{
    public class GetUsersRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel<string>> ExecCommand(RepositoryPowerShellParamModel param)
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

            Func<string, string> convertOutput = (jsonOutput) =>
            {
                using (JsonDocument doc = JsonDocument.Parse(jsonOutput))
                {
                    var usersJson = doc.RootElement.GetProperty("Users").GetRawText();
                    var psComputerName = doc.RootElement.GetProperty("PSComputerName").GetString();
                    var localUsersResponse = new LocalUsersResponse
                    {
                        Users = JsonSerializer.Deserialize<List<LocalUser>>(usersJson),
                        PSComputerName = psComputerName,
                        IpAddress = param.Ip,
                        Timestamp = DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                    };
                    return JsonSerializer.Serialize(localUsersResponse);
                }
            };

            return await base.ExecCommand<string>(param, command, convertOutput);
        }
    }
}