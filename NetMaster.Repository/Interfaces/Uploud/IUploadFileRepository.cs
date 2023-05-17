﻿// NetMaster.Services/Interfaces/Software/IUploadFileRepository.cs
using NetMaster.Common;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Repository.Interfaces.Uploud
{
    [AutoDI]
    public interface IUploadFileRepository
    {
        RepositoryResultModel<string> UploadFile(string fileName, byte[] fileData, string destinationFolder);
    }
}
