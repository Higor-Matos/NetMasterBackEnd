using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NetMaster.Domain.Models.Results;
using NetMaster.Services.Interfaces.Upload;
using NetMaster.Domain.Models.Results.Service;

namespace NetMaster.Presentation.Controllers
{
    [ApiController]
    [Route("upload")]
    public class UploadController : BaseController
    {
        private readonly IUploadService _uploadService;

        public UploadController(IUploadService uploadService)
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
