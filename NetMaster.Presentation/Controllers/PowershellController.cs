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
        public async Task<IActionResult> Post(string ip)
        {
            var result = await powershellservices.ShutdownPcComand(ip);
            return this.ToResult(result);
        }

    }
}