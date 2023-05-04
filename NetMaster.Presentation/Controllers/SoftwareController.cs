﻿using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.Results;
using NetMaster.Services;

[ApiController]
[Route("software")]
public class SoftwareController : BaseController
{
    private readonly SoftwareService _softwareService;

    public SoftwareController(SoftwareService softwareService)
    {
        _softwareService = softwareService;
    }

    [HttpPost("installAdobeReader")]
    public async Task<IActionResult> InstallAdobeReader([FromBody] IpRequestController request)
    {
        ServiceResultModel<object> result = await _softwareService.InstallAdobeReaderComand(request.Ip);
        return ToActionResult(result);
    }

    [HttpPost("installFirefox")]
    public async Task<IActionResult> InstallFirefox([FromBody] IpRequestController request)
    {
        ServiceResultModel<object> result = await _softwareService.InstallFirefoxComand(request.Ip);
        return ToActionResult(result);
    }

    [HttpPost("installGoogleChrome")]
    public async Task<IActionResult> InstallGoogleChrome([FromBody] IpRequestController request)
    {
        ServiceResultModel<object> result = await _softwareService.InstallGoogleChromeComand(request.Ip);
        return ToActionResult(result);
    }

    [HttpPost("installOffice365")]
    public async Task<IActionResult> InstallOffice365([FromBody] IpRequestController request)
    {
        ServiceResultModel<object> result = await _softwareService.InstallOffice365Comand(request.Ip);
        return ToActionResult(result);
    }

    [HttpPost("installVlc")]
    public async Task<IActionResult> InstallVlc([FromBody] IpRequestController request)
    {
        ServiceResultModel<object> result = await _softwareService.InstallVlcComand(request.Ip);
        return ToActionResult(result);
    }

    [HttpPost("instalWinrar")]
    public async Task<IActionResult> InstallWinrar([FromBody] IpRequestController request)
    {
        ServiceResultModel<object> result = await _softwareService.InstallWinrarComand(request.Ip);
        return ToActionResult(result);
    }
}