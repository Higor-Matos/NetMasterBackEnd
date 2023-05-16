// NetMaster.Controllers/SoftwareController.cs
using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.Request;
using NetMaster.Services.Implementations.Software;

namespace NetMaster.Presentation.Controllers
{
    [ApiController]
    [Route("software")]
    public class SoftwareController : BaseController
    {
        private readonly SoftwareService _softwareService;

        public SoftwareController(SoftwareService softwareService)
        {
            _softwareService = softwareService;
        }

        [HttpPost("install")]
        public async Task<IActionResult> InstallSoftware([FromBody] SoftwareInstallRequest request)
        {
            await _softwareService.InstallSoftware(request.Ip, request.SoftwareName);
            return Ok();
        }
    }
}