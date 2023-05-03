using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Domain.Models;

public class VerifyChocolateyRepository : BasePowershellRepository
{
    public async Task<RepositoryResultModel<ChocolateyInfo>> ExecCommand(RepositoryPowerShellParamModel param)
    {
        string command = "choco -v; (Get-WmiObject -Class Win32_ComputerSystem).Name";

        Func<string, ChocolateyInfo> convertOutput = (output) =>
        {
            var lines = output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            return new ChocolateyInfo
            {
                ChocolateyVersion = lines[0].Trim(),
                IpAddress = param.Ip,
                PSComputerName = lines.Length > 1 ? lines[1].Trim() : string.Empty,
                Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
            };
        };

        return await ExecCommand(param, command, convertOutput);
    }
}
