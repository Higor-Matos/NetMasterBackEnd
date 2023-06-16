// NetMaster.Services.Interfaces.Upload/IFileValidationService.cs
using Microsoft.AspNetCore.Http;
using NetMaster.Common;
using NetMaster.Domain.Models.Results.Service;

namespace NetMaster.Repository.Interfaces.Upload
{
    [AutoDI]
    public interface IFileValidationService
    {
        ServiceResultModel<object> ValidateFile(IFormFile file);
    }
}