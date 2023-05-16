// NetMaster.Controllers/HardwareController.cs
using Microsoft.AspNetCore.Mvc;
using NetMaster.Services.Interfaces.Hardware;

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
            Domain.Models.Results.ServiceResultModel<Domain.Models.DataModels.RamInfoDataModel> result = await _hardwareService.GetRamInfoAsync(computerName);
            return ToActionResult(result);
        }

        [HttpGet("getInfo/storage/{computerName}")]
        public async Task<IActionResult> GetStorageInfo(string computerName)
        {
            Domain.Models.Results.ServiceResultModel<Domain.Models.DataModels.StorageInfoDataModel> result = await _hardwareService.GetStorageInfoAsync(computerName);
            return ToActionResult(result);
        }
    }
}
