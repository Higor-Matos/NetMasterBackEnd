using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Extensions;
using NetMaster.Services;
using NetMaster.Services.Powershell;
using NetMaster.Services.Powershell.PowershellServices;

namespace NetMaster.Controllers
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

            var destinationFolder = "uploads";
            var fileData = new byte[file.Length];

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                fileData = memoryStream.ToArray();
            }

            var result = uploadService.UploadFile(file.FileName, fileData, destinationFolder);
            return this.ToResult(result);
        }


        [HttpPost("getUsers")]
        public async Task<IActionResult> GetUsers([FromBody] IpRequestController request)
        {
            var result = await systemService.GetUsers(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("getOsVersion")]
        public async Task<IActionResult> GetOsVersion([FromBody] IpRequestController request)
        {
            var result = await systemService.GetOsVersion(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("getInstalledPrograms")]
        public async Task<IActionResult> GetInstalledPrograms([FromBody] IpRequestController request)
        {
            var result = await systemService.GetInstalledPrograms(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("getRam")]
        public async Task<IActionResult> GetRamUsage([FromBody] IpRequestController request)
        {
            var result = await hardwareService.GetRam(request.Ip);
            return this.ToResult(result);
        }


        [HttpPost("getStorage")]
        public async Task<IActionResult> GetStorageUsage([FromBody] IpRequestController request)
        {
            var result = await hardwareService.GetStorage(request.Ip);
            return this.ToResult(result);
        }


        [HttpPost("shutdownPc")]
        public async Task<IActionResult> ShutdownPc([FromBody] IpRequestController request)
        {
            var result = await systemService.ShutdownPcComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("restartPc")]
        public async Task<IActionResult> RestartPc([FromBody] IpRequestController request)
        {
            var result = await systemService.RestartPcComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("verifyChocolateyVersion")]
        public async Task<IActionResult> VerifyChocolateyVersion([FromBody] IpRequestController request)
        {
            var result = await softwareService.VerifyChocolateyComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("installAdobeReader")]
        public async Task<IActionResult> InstallAdobeReader([FromBody] IpRequestController request)
        {
            var result = await softwareService.InstallAdobeReaderComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("installFirefox")]
        public async Task<IActionResult> InstallFirefox([FromBody] IpRequestController request)
        {
            var result = await softwareService.InstallFirefoxComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("installGoogleChrome")]
        public async Task<IActionResult> InstallGoogleChrome([FromBody] IpRequestController request)
        {
            var result = await softwareService.InstallGoogleChromeComand(request.Ip);
            return this.ToResult(result);
        }


        [HttpPost("installOffice365")]
        public async Task<IActionResult> InstallOffice365([FromBody] IpRequestController request)
        {
            var result = await softwareService.InstallOffice365Comand(request.Ip);
            return this.ToResult(result);
        }


        [HttpPost("installVlc")]
        public async Task<IActionResult> InstallVlc([FromBody] IpRequestController request)
        {
            var result = await softwareService.InstallVlcComand(request.Ip);
            return this.ToResult(result);
        }

        [HttpPost("instalWinrar")]
        public async Task<IActionResult> InstallWinrar([FromBody] IpRequestController request)
        {
            var result = await softwareService.InstallWinrarComand(request.Ip);
            return this.ToResult(result);
        }


        [HttpGet("listComputersNetwork")]
        public IActionResult ListNetworkComputer()
        {
            var computers = powershellService.ListNetworkComputerComand();
            return new JsonResult(new { success = new { result = new { computers } } });
        }


    }
}

