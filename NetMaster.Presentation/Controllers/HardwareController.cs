using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.Results;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Services.Interfaces.Hardware;
using System.Threading.Tasks;
using NetMaster.Domain.Models.Results.Service;

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
            ServiceResultModel<RamInfoDataModel> result = await _hardwareService.GetRamInfoAsync(computerName);
            return ToActionResult(result);
        }

        [HttpGet("getInfo/storage/{computerName}")]
        public async Task<IActionResult> GetStorageInfo(string computerName)
        {
            ServiceResultModel<StorageInfoDataModel> result = await _hardwareService.GetStorageInfoAsync(computerName);
            return ToActionResult(result);
        }
    }
}
