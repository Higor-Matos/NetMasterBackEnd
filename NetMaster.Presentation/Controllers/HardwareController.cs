// NetMaster.Controllers/HardwareController.cs
using Microsoft.AspNetCore.Mvc;
using NetMaster.Services.Interfaces;
using NetMaster.Repository.Interfaces;

namespace NetMaster.Presentation.Controllers
{
    [ApiController]
    [Route("hardware")]
    public class HardwareController : BaseController
    {
        private readonly IHardwareService _hardwareService;

        public HardwareController(IHardwareService hardwareService)
        {
            _hardwareService = hardwareService;
        }

        [HttpGet("getInfo/ram/{computerName}")]
        public async Task<IActionResult> GetRamInfo(string computerName)
        {
            var result = await _hardwareService.GetRamInfoAsync(computerName);
            return ToActionResult(result);
        }

        [HttpGet("getInfo/storage/{computerName}")]
        public async Task<IActionResult> GetStorageInfo(string computerName)
        {
            var result = await _hardwareService.GetStorageInfoAsync(computerName);
            return ToActionResult(result);
        }
    }
}
