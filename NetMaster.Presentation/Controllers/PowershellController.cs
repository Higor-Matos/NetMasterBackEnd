using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Extensions;
using NetMaster.Services.Powershell;
using NetMaster.Services.Network;

namespace NetMaster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowershellController : ControllerBase
    {
        private readonly PowershellServices powershellservices = new();
        private readonly NetworkServices networkservices = new();

        [HttpPost("shutdownPc")]
        public async Task<IActionResult> ShutdownPc(string ip)
        {
            var result = await powershellservices.ShutdownPcComand(ip);
            return this.ToResult(result);
        }

        [HttpPost("restartPc")]
        public async Task<IActionResult> RestartPc(string ip)
        {
            var result = await powershellservices.RestartPcComand(ip);
            return this.ToResult(result);
        }

        [HttpPost("verifyChocolateyVersion")]
        public async Task<IActionResult> VerifyChocolateyVersion(string ip)
        {
            var result = await powershellservices.VerifyChocolateyComand(ip);
            return this.ToResult(result);
        }

        [HttpPost("installAdobeReader")]
        public async Task<IActionResult> InstallAdobeReader(string ip)
        {
            var result = await powershellservices.InstallAdobeReaderComand(ip);
            return this.ToResult(result);
        }

        [HttpPost("listComputersNetwork")]
        public async Task<IActionResult> ListNetworkComputer(string domain)
        {
            var result = await networkservices.ListNetworkComputerComand(domain);
            return this.ToResult(result);
        }

    }
}