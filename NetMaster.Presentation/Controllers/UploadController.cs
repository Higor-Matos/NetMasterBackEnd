using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.Results;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Services.Interfaces.Upload;

namespace NetMaster.Presentation.Controllers
{
    [ApiController]
    [Route("upload")]
    public class UploadController : BaseController
    {
        private readonly IFileUploadService _uploadService;

        public UploadController(IFileUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPost("file")]
        public IActionResult UploadFile(IFormFile file)
        {
            ServiceResultModel<object> validationResult = _uploadService.ValidateFile(file);
            if (!validationResult.IsSuccess)
            {
                return ToActionResult(validationResult);
            }

            ServiceResultModel<UploadResult> result = _uploadService.UploadFile(file);
            return ToActionResult(result);
        }
    }
}
