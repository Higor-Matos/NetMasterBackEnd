// NetMaster.Services.Interfaces.Upload/IFileUploadService.cs
using Microsoft.AspNetCore.Http;
using NetMaster.Common;
using NetMaster.Domain.Models.Results.Service;

namespace NetMaster.Services.Interfaces.Upload
{
    [AutoDI]
    public interface IFileUploadService
    {
        ServiceResultModel<string> UploadFile(IFormFile file);
    }
}