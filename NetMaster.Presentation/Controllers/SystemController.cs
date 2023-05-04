using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Services;
using System.DirectoryServices.ActiveDirectory;

[ApiController]
[Route("system")]
public class SystemController : BaseController
{
    private readonly SystemService _systemService;

    public SystemController(SystemService systemService)
    {
        _systemService = systemService;
    }

    [HttpPost("getUsers")]
    public async Task<IActionResult> GetUsers([FromBody] IpRequestController request)
    {
        ServiceResultModel<LocalUsersInfoDataModel> result = await _systemService.GetUsers(request.Ip);
        return ToActionResult(result);
    }

    [HttpPost("shutdownPc")]
    public async Task<IActionResult> ShutdownPc([FromBody] IpRequestController request)
    {
        ServiceResultModel<object> result = await _systemService.ShutdownPcComand(request.Ip);
        return this.ToActionResult(result);
    }

    [HttpPost("restartPc")]
    public async Task<IActionResult> RestartPc([FromBody] IpRequestController request)
    {
        ServiceResultModel<object> result = await _systemService.RestartPcComand(request.Ip);
        return this.ToActionResult(result);
    }

    [HttpPost("verifyChocolateyVersion")]
    public async Task<IActionResult> VerifyChocolateyVersion([FromBody] IpRequestController request)
    {
        ServiceResultModel<ChocolateyInfoDataModel> result = await _systemService.VerifyChocolateyComand(request.Ip);
        return this.ToActionResult(result);
    }


    [HttpPost("getOsVersion")]
    public async Task<IActionResult> GetOsVersion([FromBody] IpRequestController request)
    {
        ServiceResultModel<OSVersionInfoDataModel> result = await _systemService.GetOsVersion(request.Ip);
        return this.ToActionResult(result);
    }
}
