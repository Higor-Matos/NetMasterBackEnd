using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.Request;
using NetMaster.Services.Interfaces;
using NetMaster.Services.Interfaces.Software;

namespace NetMaster.Presentation.Controllers
{
    [ApiController]
    [Route("software")]
    public class SoftwareController : BaseController
    {
        private readonly ISoftwareService _softwareService;

        public SoftwareController(ISoftwareService softwareService)
        {
            _softwareService = softwareService;
        }

        [HttpPost("install")]
        public IActionResult InstallSoftware([FromBody] SoftwareInstallRequest request)
        {
            _softwareService.InstallSoftware(request.Ip, request.SoftwareName);
            return Ok();
        }
    }
}
