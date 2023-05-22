using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results.Service;
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
            IActionResult nameCheckResult = CheckComputerNameIsNull(computerName);
            if (nameCheckResult != null)
            {
                return nameCheckResult;
            }

            ServiceResultModel<RamInfoDataModel> result = await _hardwareService.GetRamInfoAsync(computerName!);
            return ToActionResult(result);
        }

        [HttpGet("getInfo/storage/{computerName}")]
        public async Task<IActionResult> GetStorageInfo(string computerName)
        {
            IActionResult nameCheckResult = CheckComputerNameIsNull(computerName);
            if (nameCheckResult != null)
            {
                return nameCheckResult;
            }

            ServiceResultModel<StorageInfoDataModel> result = await _hardwareService.GetStorageInfoAsync(computerName!);
            return ToActionResult(result);
        }

        private new IActionResult? CheckComputerNameIsNull(string computerName)
        {
            return string.IsNullOrEmpty(computerName) ? BadRequest("Computer name is required.") : (IActionResult?)null;
        }
    }
}
