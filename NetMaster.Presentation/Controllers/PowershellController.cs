using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Extensions;
using NetMaster.Services.Powershell;
using System.Diagnostics;

namespace NetMaster.Controllers
{
    [ApiController]
    [Route("powershell")]
    public class PowershellController : ControllerBase
    {
        private readonly PowershellService powershellService = new();

        [HttpPost("shutdownPc")]
        public async Task<IActionResult> ShutdownPc(string ip)
        {
            var result = await powershellService.ShutdownPcComand(ip);
            return this.ToResult(result);
        }

        [HttpPost("restartPc")]
        public async Task<IActionResult> RestartPc(string ip)
        {
            var result = await powershellService.RestartPcComand(ip);
            return this.ToResult(result);
        }

        [HttpPost("verifyChocolateyVersion")]
        public async Task<IActionResult> VerifyChocolateyVersion(string ip)
        {
            var result = await powershellService.VerifyChocolateyComand(ip);
            return this.ToResult(result);
        }

        [HttpPost("installAdobeReader")]
        public async Task<IActionResult> InstallAdobeReader(string ip)
        {
            var result = await powershellService.InstallAdobeReaderComand(ip);
            return this.ToResult(result);
        }

        [HttpPost("listComputersNetwork")]
        public IActionResult ListNetworkComputer(string ip)
        {
            var jsonResult = powershellService.ListNetworkComputerComand(ip);
            return new JsonResult(jsonResult);
        }
    }
}
