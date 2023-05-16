using NetMaster.Domain.Models;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Implementation.Powershell;

public class LocalChocolateyRepository : BasePowershellRepository
{
    public async Task<RepositoryResultModel<ChocolateyInfoDataModel>> ExecCommand(RepositoryPowerShellParamModel param)
    {
        string command = "choco -v; (Get-WmiObject -Class Win32_ComputerSystem).Name";

        ChocolateyInfoDataModel convertOutput(string output)
        {
            string[] lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            TimeZoneInfo brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            DateTime brasiliaTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brasiliaTimeZone);
            return new ChocolateyInfoDataModel
            {
                ChocolateyVersion = lines[0].Trim(),
                IpAddress = param.Ip,
                PSComputerName = lines.Length > 1 ? lines[1].Trim() : string.Empty,
                Timestamp = brasiliaTime
            };
        }

        return await ExecCommand(param, command, convertOutput);
    }
}
