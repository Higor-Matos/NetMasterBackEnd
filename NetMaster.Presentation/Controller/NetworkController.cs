using Microsoft.AspNetCore.Mvc;
using NetMaster.Presentation.Controllers;
using NetMaster.Services.Implementations.Network;

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
        object[] computers = _powershellService.ListNetworkComputerCommand();
        return new JsonResult(new { success = new { result = new { computers } } });
    }
}


