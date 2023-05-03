using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using NetMaster.Domain.Models.Results;
using Newtonsoft.Json.Linq;

namespace NetMaster.Repository.Local.Powershell.Software
{
    public class GetInstalledProgramsRepository : BasePowershellRepository
    {
        public async Task<RepositoryResultModel<InstalledProgramsResponse>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = @"
                $programs = choco list --local-only | Select-Object -Skip 1 | Where-Object { $_ -notmatch '^\\d+ packages installed' } | Where-Object { $_ -notmatch '^KB\\d+' } | Where-Object { $_ -notmatch '\\d+ packages installed' };
                $computerName = (Get-WmiObject -Class Win32_ComputerSystem).Name;
                @{
                    'Programs' = $programs;
                    'PSComputerName' = $computerName;
                } | ConvertTo-Json
            ";

            Func<string, InstalledProgramsResponse> convertOutput = (jsonOutput) =>
            {
                JObject resultJson = JObject.Parse(jsonOutput);
                var installedProgramNames = resultJson["Programs"].ToObject<List<string>>();
                var installedPrograms = new List<InstalledProgram>();
                foreach (var name in installedProgramNames)
                {
                    installedPrograms.Add(new InstalledProgram { Name = name });
                }
                return new InstalledProgramsResponse
                {
                    InstalledPrograms = installedPrograms,
                    IpAddress = param.Ip,
                    PSComputerName = resultJson["PSComputerName"].ToString(),
                    Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                };
            };

            return await base.ExecCommand(param, command, convertOutput);
        }
    }
}
