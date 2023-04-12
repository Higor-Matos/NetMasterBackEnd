using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Linq;

namespace NetMaster.Controllers
{
    [ApiController]
    [Route("streaming")]
    public class StreamingServerController : ControllerBase
    {
        private readonly StreamingServerConfigPresentation config;
        private Process streamingServerProcess;

        public StreamingServerController(IOptions<StreamingServerConfigPresentation> config)
        {
            this.config = config.Value;
        }

        [HttpPost("toggle")]
        public IActionResult ToggleStreamingServer()
        {
            var processName = "ScreenStreamingServer";
            var isRunning = Process.GetProcessesByName(processName).Any();

            if (isRunning)
            {
                var process = Process.GetProcessesByName(processName).FirstOrDefault();
                process?.Kill();

                return Ok("Streaming server stopped.");
            }
            else
            {
                var processStartInfo = new ProcessStartInfo()
                {
                    FileName = config.FileName,
                    UseShellExecute = config.UseShellExecute,
                    RedirectStandardOutput = config.RedirectStandardOutput,
                    CreateNoWindow = config.CreateNoWindow
                };

                streamingServerProcess = new Process
                {
                    StartInfo = processStartInfo
                };
                streamingServerProcess.Start();

                return Ok("Streaming server started.");
            }
        }
    }
}
