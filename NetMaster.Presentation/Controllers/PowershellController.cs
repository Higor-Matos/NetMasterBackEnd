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


        [HttpPost("getUsers")]
        public async Task<IActionResult> GetUsers([FromBody] IpRequestController request)
        {
            var result = await powershellService.GetUsers(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("getOsVersion")]
        public async Task<IActionResult> GetOsVersion([FromBody] IpRequestController request)
        {
            var result = await powershellService.GetOsVersion(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("getInstalledPrograms")]
        public async Task<IActionResult> GetInstalledPrograms([FromBody] IpRequestController request)
        {
            var result = await powershellService.GetInstalledPrograms(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("getRam")]
        public async Task<IActionResult> GetRamUsage([FromBody] IpRequestController request)
        {
            var result = await powershellService.GetRamUsage(request.Ip);
            return this.ToResult(result);
        }


        [HttpPost("getStorage")]
        public async Task<IActionResult> GetStorageUsage([FromBody] IpRequestController request)
        {
            var result = await powershellService.getStorage(request.Ip);
            return this.ToResult(result);
        }


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

        [HttpPost("installFirefox")]
        public async Task<IActionResult> InstallFirefox([FromBody] IpRequestController request)
        {
            var result = await powershellService.InstallFirefoxComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("installGoogleChrome")]
        public async Task<IActionResult> InstallGoogleChrome([FromBody] IpRequestController request)
        {
            var result = await powershellService.InstallGoogleChromeComand(request.Ip);
            return this.ToResult(result);
        }


        [HttpPost("installOffice365")]
        public async Task<IActionResult> InstallOffice365([FromBody] IpRequestController request)
        {
            var result = await powershellService.InstallOffice365Comand(request.Ip);
            return this.ToResult(result);
        }


        [HttpPost("installVlc")]
        public async Task<IActionResult> InstallVlc([FromBody] IpRequestController request)
        {
            var result = await powershellService.InstallVlcComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("instalWinrar")]
        public async Task<IActionResult> InstallWinrar([FromBody] IpRequestController request)
        {
            var result = await powershellService.InstallWinrarComand(request.Ip);
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
