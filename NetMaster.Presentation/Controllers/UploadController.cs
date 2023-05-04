// UploadController.cs
using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.Results;
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

    private IActionResult ValidateFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File not provided or empty.");
        }

        return null;
    }
}
