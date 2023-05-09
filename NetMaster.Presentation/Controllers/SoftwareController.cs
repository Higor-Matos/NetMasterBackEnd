using Microsoft.AspNetCore.Mvc;
using NetMaster.Services;
using System.Threading.Tasks;

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

        [HttpPost("install/{software}")]
        public async Task<IActionResult> InstallSoftware([FromBody] IpRequestController request, string software)
        {
            var result = await _softwareService.InstallSoftwareCommand(request.Ip, software);
            return ToActionResult(result);
        }
    }
}