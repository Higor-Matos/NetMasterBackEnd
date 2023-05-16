// NetMaster.Services/Interfaces/Uploud/IUploadService.cs
using Microsoft.AspNetCore.Http;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Services.Interfaces.Uploud
{
    public interface IUploadService
    {
        ServiceResultModel<object> UploadFile(IFormFile file);
    }
}
