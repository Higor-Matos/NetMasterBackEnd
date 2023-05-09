using Microsoft.AspNetCore.Mvc;
using NetMaster.Services;

namespace NetMaster.Presentation.Controllers
{
    [ApiController]
    [Route("network")]
    public class NetworkController : BaseController
    {
        private readonly NetworkService _powershellService;

        public NetworkController(NetworkService powershellService)
        {
            _powershellService = powershellService;
        }

        [HttpGet("listComputersNetwork")]
        public IActionResult ListNetworkComputer()
        {
            object[] computers = _powershellService.ListNetworkComputerComand();
            return new JsonResult(new { success = new { result = new { computers } } });
        }
    }
}