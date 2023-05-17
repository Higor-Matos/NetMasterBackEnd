using Microsoft.AspNetCore.Mvc;
using NetMaster.Services.Interfaces.Network;

namespace NetMaster.Presentation.Controllers
{
    [ApiController]
    [Route("network")]
    public class NetworkController : BaseController
    {
        private readonly INetworkService _networkService;

        public NetworkController(INetworkService networkService)
        {
            _networkService = networkService;
        }

        [HttpGet("listComputersNetwork")]
        public IActionResult ListNetworkComputer()
        {
            object[] computers = _networkService.ListNetworkComputerCommand();
            return new JsonResult(new { success = new { result = new { computers } } });
        }
    }
}