// NetMaster.Repository/Implementation/System/LocalChocolateyRepository.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Repository;
using NetMaster.Repository.Implementation.Powershell;
using NetMaster.Repository.Interfaces.System;

namespace NetMaster.Repository.Implementation.System
{
    public class LocalChocolateyRepository : BasePowershellRepository, ILocalChocolateyRepository
    {
        public async Task<RepositoryResultModel<ChocolateyInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param)
        {
            string command = "choco -v; (Get-WmiObject -Class Win32_ComputerSystem).Name";

            return await ExecCommand(param, command, output => ConvertOutput<ChocolateyInfoDataModel>(output, param.Ip));
        }

        private ChocolateyInfoDataModel ConvertOutput(string output, string ip)
        {
            string[] lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            TimeZoneInfo brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            DateTime brasiliaTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brasiliaTimeZone);
            return new ChocolateyInfoDataModel
            {
                ChocolateyVersion = lines[0].Trim(),
                IpAddress = ip,
                PSComputerName = lines.Length > 1 ? lines[1].Trim() : string.Empty,
                Timestamp = brasiliaTime
            };
        }
    }
}