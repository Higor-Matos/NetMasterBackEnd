using NetMaster.Domain.Models.Results;
using NetMaster.Presentation.Controllers;
using NetMaster.Services;

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
            Domain.Models.Results.ServiceResultModel<object> result = await _softwareService.InstallSoftwareCommand(request.Ip, software);
            return ToActionResult(result);
        }
    }
}