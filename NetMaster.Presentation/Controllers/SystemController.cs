// SystemController.cs
using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Services.Interfaces.System;

namespace NetMaster.Presentation.Controllers
{
    [ApiController]
    [Route("system")]
    public class SystemController : BaseController
    {
        private readonly ISystemService _systemService;
        private readonly ISystemCommandService _systemCommandService;

        public SystemController(ISystemService systemService, ISystemCommandService systemCommandService)
        {
            _systemService = systemService;
            _systemCommandService = systemCommandService;
        }

        [HttpPost("shutdownPc")]
        public async Task<IActionResult> ShutdownPc([FromBody] IpRequest request)
        {
            IActionResult ipCheckResult = CheckIpIsNull(request.Ip);
            if (ipCheckResult != null)
            {
                return ipCheckResult;
            }

            ServiceResultModel<string> result = await _systemCommandService.ShutdownPcCommand(request.Ip);
            return ToActionResult(result);
        }

        [HttpPost("restartPc")]
        public async Task<IActionResult> RestartPc([FromBody] IpRequest request)
        {

            IActionResult ipCheckResult = CheckIpIsNull(request.Ip);
            if (ipCheckResult != null)
            {
                return ipCheckResult;
            }

            ServiceResultModel<string> result = await _systemCommandService.RestartPcCommand(request.Ip);
            return ToActionResult(result);
        }

        [HttpGet("getUsersInfo/{computerName}")]
        public async Task<IActionResult> GetUsersInfo(string computerName)
        {
            IActionResult nameCheckResult = CheckComputerNameIsNull(computerName);
            if (nameCheckResult != null)
            {
                return nameCheckResult;
            }

            ServiceResultModel<UsersInfoDataModel> result = await _systemService.GetUsersInfoAsync(computerName);
            return ToActionResult(result);
        }

        [HttpGet("getChocolateyInfo/{computerName}")]
        public async Task<IActionResult> GetChocolateyInfo(string computerName)
        {
            IActionResult nameCheckResult = CheckComputerNameIsNull(computerName);
            if (nameCheckResult != null)
            {
                return nameCheckResult;
            }
            ServiceResultModel<ChocolateyInfoDataModel> result = await _systemService.GetChocolateyInfoAsync(computerName);
            return ToActionResult(result);
        }

        [HttpGet("getOsVersionInfo/{computerName}")]
        public async Task<IActionResult> GetOsVersionInfo(string computerName)
        {
            IActionResult nameCheckResult = CheckComputerNameIsNull(computerName);
            if (nameCheckResult != null)
            {
                return nameCheckResult;
            }
            ServiceResultModel<OSVersionInfoDataModel> result = await _systemService.GetOsVersionInfoAsync(computerName);
            return ToActionResult(result);
        }

        [HttpGet("getInstalledProgramsInfo/{computerName}")]
        public async Task<IActionResult> GetInstalledProgramsInfo(string computerName)
        {
            IActionResult nameCheckResult = CheckComputerNameIsNull(computerName);
            if (nameCheckResult != null)
            {
                return nameCheckResult;
            }
            ServiceResultModel<InstalledProgramsResponseModel> result = await _systemService.GetInstalledProgramsInfoAsync(computerName);
            return ToActionResult(result);
        }
    }
}
