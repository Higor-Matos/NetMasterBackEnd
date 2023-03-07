using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Extensions;
using NetMaster.Services.Powershell;

namespace NetMaster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowershellController : ControllerBase
    {
        private readonly PowershellServices powershellservices = new();

        [HttpPost]
        public async Task<IActionResult> ShutdownPc(string ip)
        {
            var result = await powershellservices.VerifyChocolateyComand(ip);
            return this.ToResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> RestartPc(string ip)
        {
            var result = await powershellservices.RestartPcComand(ip);
            return this.ToResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> VerifyChocolateyVersion(string ip)
        {
            var result = await powershellservices.VerifyChocolateyComand(ip);
            return this.ToResult(result);
        }

    }
}