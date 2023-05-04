using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Extensions;
using NetMaster.Domain.Models.DataModels;
using NetMaster.Domain.Models.Results;
using NetMaster.Services;
using NetMaster.Services.Powershell;

namespace NetMaster.Presentation.Controllers
{
    [ApiController]
    [Route("powershell")]
    public class PowershellController : ControllerBase
    {
        private readonly HardwareService hardwareService;
        private readonly SoftwareService softwareService;
        private readonly SystemService systemService;
        private readonly UploadService uploadService;
        private readonly PowershellService powershellService;

        public PowershellController(HardwareService hardwareService, SoftwareService softwareService, SystemService systemService, UploadService uploadService, PowershellService powershellService)
        {
            this.hardwareService = hardwareService;
            this.softwareService = softwareService;
            this.systemService = systemService;
            this.uploadService = uploadService;
            this.powershellService = powershellService;
        }

        [HttpPost("uploadFile")]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File not provided or empty.");
            }

            string destinationFolder = "uploads";
            byte[] fileData = new byte[file.Length];

            using (MemoryStream memoryStream = new())
            {
                file.CopyTo(memoryStream);
                fileData = memoryStream.ToArray();
            }

            ServiceResultModel<object> result = uploadService.UploadFile(file.FileName, fileData, destinationFolder);
            return this.ToResult(result);
        }

        [HttpPost("getUsers")]
        public async Task<IActionResult> GetUsers([FromBody] IpRequestController request)
        {
            ServiceResultModel<Domain.Models.DataModels.LocalUsersInfoModel> result = await systemService.GetUsers(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("getOsVersion")]
        public async Task<IActionResult> GetOsVersion([FromBody] IpRequestController request)
        {
            ServiceResultModel<Domain.Models.DataModels.OSVersionInfoModel> result = await systemService.GetOsVersion(request.Ip);
            return this.ToResult(result);
        }
  
        [HttpPost("getInstalledPrograms")]
        public async Task<IActionResult> GetInstalledPrograms([FromBody] IpRequestController request)
        {
            ServiceResultModel<InstalledProgramsResponseModel> result = await systemService.GetInstalledPrograms(request.Ip);
            return this.ToResult(result);
        }


        [HttpPost("getRam")]
        public async Task<IActionResult> GetRamUsage([FromBody] IpRequestController request)
        {
            Domain.Models.Results.ServiceResultModel<Domain.Models.DataModels.RamInfoModel> result = await hardwareService.GetRam(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("getStorage")]
        public async Task<IActionResult> GetStorageUsage([FromBody] IpRequestController request)
        {
            ServiceResultModel<Domain.Models.DataModels.StorageInfoModel> result = await hardwareService.GetStorage(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("shutdownPc")]
        public async Task<IActionResult> ShutdownPc([FromBody] IpRequestController request)
        {
            ServiceResultModel<object> result = await systemService.ShutdownPcComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("restartPc")]
        public async Task<IActionResult> RestartPc([FromBody] IpRequestController request)
        {
            ServiceResultModel<object> result = await systemService.RestartPcComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("verifyChocolateyVersion")]
        public async Task<IActionResult> VerifyChocolateyVersion([FromBody] IpRequestController request)
        {
            ServiceResultModel<Domain.Models.DataModels.ChocolateyInfoModel> result = await systemService.VerifyChocolateyComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("installAdobeReader")]
        public async Task<IActionResult> InstallAdobeReader([FromBody] IpRequestController request)
        {
            ServiceResultModel<object> result = await softwareService.InstallAdobeReaderComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("installFirefox")]
        public async Task<IActionResult> InstallFirefox([FromBody] IpRequestController request)
        {
            ServiceResultModel<object> result = await softwareService.InstallFirefoxComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("installGoogleChrome")]
        public async Task<IActionResult> InstallGoogleChrome([FromBody] IpRequestController request)
        {
            ServiceResultModel<object> result = await softwareService.InstallGoogleChromeComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("installOffice365")]
        public async Task<IActionResult> InstallOffice365([FromBody] IpRequestController request)
        {
            ServiceResultModel<object> result = await softwareService.InstallOffice365Comand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("installVlc")]
        public async Task<IActionResult> InstallVlc([FromBody] IpRequestController request)
        {
            ServiceResultModel<object> result = await softwareService.InstallVlcComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("instalWinrar")]
        public async Task<IActionResult> InstallWinrar([FromBody] IpRequestController request)
        {
            ServiceResultModel<object> result = await softwareService.InstallWinrarComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpGet("listComputersNetwork")]
        public IActionResult ListNetworkComputer()
        {
            object[] computers = powershellService.ListNetworkComputerComand();
            return new JsonResult(new { success = new { result = new { computers } } });
        }
    }
}

