using Microsoft.AspNetCore.Mvc;
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
            string result = await powershellservices.ShutdownPcComand(ip);
            if (result == "")
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}