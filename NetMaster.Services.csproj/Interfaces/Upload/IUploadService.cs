// NetMaster.Services.Interfaces.Upload
using Microsoft.AspNetCore.Http;
using NetMaster.Common;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.Upload
{
    [AutoDI]
    public interface IUploadService
    {
        ServiceResultModel<object> ValidateFile(IFormFile file);
        ServiceResultModel<UploadResult> UploadFile(IFormFile file);
    }
}
