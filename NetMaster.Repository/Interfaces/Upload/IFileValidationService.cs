// NetMaster.Services.Interfaces.Upload/IFileValidationService.cs
using Microsoft.AspNetCore.Http;
using NetMaster.Common;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.Upload
{
    [AutoDI]
    public interface IFileValidationService
    {
        ServiceResultModel<object> ValidateFile(IFormFile file);
    }
}