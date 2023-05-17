﻿//NetMaster.Repository/Implementation/Uploud/UploadFileRepository.cs
using NetMaster.Domain.Models.Results;
using NetMaster.Repository.Interfaces.Uploud;

namespace NetMaster.Repository.Implementation.Uploud
{
    public class UploadFileRepository : IUploadFileRepository
    {
        public RepositoryResultModel<string> UploadFile(string fileName, byte[] fileData, string destinationFolder)
        {
            try
            {
                string filePath = Path.Combine(destinationFolder, fileName);
                WriteFileData(filePath, fileData);

                return new RepositoryResultModel<string>(data: "File uploaded successfully.", success: true);
            }
            catch (Exception e)
            {
                return new RepositoryResultModel<string>(error: new ErrorRepositoryResult(e));
            }
        }


        private void WriteFileData(string filePath, byte[] fileData)
        {
            File.WriteAllBytes(filePath, fileData);
        }
    }
}