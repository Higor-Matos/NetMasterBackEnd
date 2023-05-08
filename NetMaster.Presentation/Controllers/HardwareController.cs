using Microsoft.AspNetCore.Mvc;
using NetMaster.Services;

[ApiController]
[Route("hardware")]
public class HardwareController : BaseController
{
    private readonly HardwareService _hardwareService;

    public HardwareController(HardwareService hardwareService)
    {
        _hardwareService = hardwareService;
    }

    [HttpGet("getInfo/{infoType}/{computerName}")]
    public async Task<IActionResult> GetInfo(string infoType, string computerName)
    {
        var result = await _hardwareService.GetInfoAsync(infoType, computerName);
        return ToActionResult(result);
    }
}
