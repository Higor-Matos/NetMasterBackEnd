// NetMaster.Presentation/Controllers/SystemService.cs
using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Services;

namespace NetMaster.Presentation.Controllers
{
    [ApiController]
    [Route("system")]
    public class SystemController : BaseController
    {
        private readonly SystemCommandService _systemCommandService;
        private readonly SystemService _systemService;

        public SystemController(SystemCommandService systemCommandService, SystemService systemService)
        {
            _systemCommandService = systemCommandService;
            _systemService = systemService;
        }

        [HttpPost("shutdownPc")]
        public async Task<IActionResult> ShutdownPc([FromBody] IpRequestController request)
        {
            Domain.Models.Results.ServiceResultModel<object> result = await _systemCommandService.ShutdownPcComandAsync(request.Ip);
            return ToActionResult(result);
        }

        [HttpPost("restartPc")]
        public async Task<IActionResult> RestartPc([FromBody] IpRequestController request)
        {
            Domain.Models.Results.ServiceResultModel<object> result = await _systemCommandService.RestartPcComandAsync(request.Ip);
            return ToActionResult(result);
        }

        [HttpGet("getInfo/{infoType}/{computerName}")]
        public async Task<IActionResult> GetInfo(string infoType, string computerName)
        {
            ServiceResultModel<object> result = await _systemService.GetInfoAsync(infoType, computerName);
            return result != null ? ToActionResult(result) : BadRequest($"Invalid infoType: {infoType}. Valid options are: users, chocolatey, osversion, installedprograms.");
        }

    }
}
