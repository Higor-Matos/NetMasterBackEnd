using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetMaster.Presentation.Configuration;
using System.Diagnostics;

namespace NetMaster.Presentation.Controllers
{
    [ApiController]
    [Route("streaming")]
    public class StreamingServerController : ControllerBase
    {
        private readonly StreamingServerConfigPresentation _config;
        private Process _streamingServerProcess;
        private const string ProcessName = "ScreenStreamingServer";
        public StreamingServerController(IOptions<StreamingServerConfigPresentation> config, IHostApplicationLifetime appLifetime)
        {
            _config = config.Value;
            _ = appLifetime.ApplicationStopping.Register(OnApplicationStopping);
        }

        [HttpPost("toggle")]
        public IActionResult ToggleStreamingServer()
        {
            try
            {
                if (IsServerRunning())
                {
                    StopStreamingServer();
                    return Ok("Streaming server stopped.");
                }
                else
                {
                    StartStreamingServer();
                    return Ok("Streaming server started.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        private bool IsServerRunning()
        {
            return Process.GetProcessesByName(ProcessName).Any();
        }

        private void StartStreamingServer()
        {
            ProcessStartInfo processStartInfo = new()
            {
                FileName = _config.FileName,
                UseShellExecute = _config.UseShellExecute,
                RedirectStandardOutput = _config.RedirectStandardOutput,
                CreateNoWindow = _config.CreateNoWindow
            };

            _streamingServerProcess = new Process { StartInfo = processStartInfo };
            _ = _streamingServerProcess.Start();
        }
        private void StopStreamingServer()
        {
            Process? process = Process.GetProcessesByName(ProcessName).FirstOrDefault();
            process?.Kill();
        }
        private void OnApplicationStopping()
        {
            StopStreamingServer();
        }
    }
}
