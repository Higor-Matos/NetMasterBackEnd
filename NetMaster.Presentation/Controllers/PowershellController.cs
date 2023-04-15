using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Extensions;
using NetMaster.Services.Powershell;

namespace NetMaster.Controllers
{
    [ApiController]
    [Route("powershell")]
    public class PowershellController : ControllerBase
    {
        private readonly PowershellService powershellService = new();

        [HttpPost("shutdownPc")]
        public async Task<IActionResult> ShutdownPc([FromBody] IpRequestController request)
        {
            var result = await powershellService.ShutdownPcComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("restartPc")]
        public async Task<IActionResult> RestartPc([FromBody] IpRequestController request)
        {
            var result = await powershellService.RestartPcComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("verifyChocolateyVersion")]
        public async Task<IActionResult> VerifyChocolateyVersion([FromBody] IpRequestController request)
        {
            var result = await powershellService.VerifyChocolateyComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("installAdobeReader")]
        public async Task<IActionResult> InstallAdobeReader([FromBody] IpRequestController request)
        {
            var result = await powershellService.InstallAdobeReaderComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpGet("listComputersNetwork")]
        public IActionResult ListNetworkComputer()
        {
            var computers = powershellService.ListNetworkComputerComand();
            return new JsonResult(new { success = new { result = new { computers } } });
        }


    }
}
