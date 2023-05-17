using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Services.Implementation.System;
using NetMaster.Services.Interfaces.System;

namespace NetMaster.Presentation.Controllers
{
    [ApiController]
    [Route("system")]
    public class SystemController : BaseController
    {
        private readonly ISystemService _systemService;
        private readonly SystemCommandService _systemCommandService;

        public SystemController(ISystemService systemService)
        {
            _systemService = systemService;
        }

        [HttpPost("shutdownPc")]
        public async Task<IActionResult> ShutdownPc([FromBody] IpRequestDataModels request)
        {
            ServiceResultModel<string> result = await _systemCommandService.ShutdownPcComand(request.Ip);
            return ToActionResult(result);
        }

        [HttpPost("restartPc")]
        public async Task<IActionResult> RestartPc([FromBody] IpRequestDataModels request)
        {
            ServiceResultModel<string> result = await _systemCommandService.RestartPcComand(request.Ip);
            return ToActionResult(result);
        }


        [HttpGet("getInfo/{infoType}/{computerName}")]
        public async Task<IActionResult> GetInfo(string infoType, string computerName)
        {
            switch (infoType.ToLower())
            {
                case "users":
                    ServiceResultModel<UsersInfoDataModel> usersResult = await _systemService.GetUsersInfoAsync(computerName);
                    return ToActionResult(usersResult);

                case "chocolatey":
                    ServiceResultModel<ChocolateyInfoDataModel> chocolateyResult = await _systemService.GetChocolateyInfoAsync(computerName);
                    return ToActionResult(chocolateyResult);

                case "osversion":
                    ServiceResultModel<OSVersionInfoDataModel> osVersionResult = await _systemService.GetOsVersionInfoAsync(computerName);
                    return ToActionResult(osVersionResult);

                case "installedprograms":
                    ServiceResultModel<InstalledProgramsResponseModel> installedProgramsResult = await _systemService.GetInstalledProgramsInfoAsync(computerName);
                    return ToActionResult(installedProgramsResult);

                default:
                    return BadRequest($"Invalid infoType: {infoType}. Valid options are: users, chocolatey, osversion, installedprograms.");
            }
        }
    }
}