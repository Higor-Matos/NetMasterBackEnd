using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
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

    [HttpPost("getRam")]
    public async Task<IActionResult> GetRamUsage([FromBody] IpRequestController request)
    {
        ServiceResultModel<RamInfoDataModel> result = await _hardwareService.GetRam(request.Ip);
        return ToActionResult(result);
    }

    [HttpPost("getStorage")]
    public async Task<IActionResult> GetStorageUsage([FromBody] IpRequestController request)
    {
        ServiceResultModel<StorageInfoDataModel> result = await _hardwareService.GetStorage(request.Ip);
        return ToActionResult(result);
    }
}
