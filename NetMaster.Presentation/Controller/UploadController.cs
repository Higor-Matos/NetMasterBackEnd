// UploadController.cs
using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.Results;
using NetMaster.Presentation.Controllers;
using NetMaster.Services;

[ApiController]
[Route("upload")]
public class UploadController : BaseController
{
    private readonly UploadService _uploadService;

    public UploadController(UploadService uploadService)
    {
        _uploadService = uploadService;
    }

    [HttpPost("file")]
    public IActionResult UploadFile(IFormFile file)
    {
        IActionResult validationResult = ValidateFile(file);
        if (validationResult != null)
        {
            return validationResult;
        }

        ServiceResultModel<object> result = _uploadService.UploadFile(file);
        return ToActionResult(result);
    }

    private IActionResult? ValidateFile(IFormFile file)
    {
        return file == null || file.Length == 0 ? BadRequest("File not provided or empty.") : (IActionResult?)null;
    }
}
