// NetMaster.Services/Implementations/Upload/FileValidationService.cs
using Microsoft.AspNetCore.Http;
using NetMaster.Domain.Models.Results;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Services.Interfaces.Upload;
using System;

namespace NetMaster.Services.Implementations.Upload
{
    public class FileValidationService : IFileValidationService
    {
        public ServiceResultModel<object> ValidateFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return new ServiceResultModel<object>(
                    error: new ErrorServiceResult("File not provided or empty.", DateTime.Now, Environment.MachineName)
                );
            }

            return new ServiceResultModel<object>(
                success: new SuccessServiceResult<object>(null, DateTime.Now, Environment.MachineName)
            );
        }
    }
}