using Microsoft.AspNetCore.Mvc;
using NetMaster.Services;

[ApiController]
[Route("network")]
public class NetworkController : BaseController
{
    private readonly PowershellService _powershellService;

    public NetworkController(PowershellService powershellService)
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


