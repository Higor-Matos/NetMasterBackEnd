// NetMaster.Infrastructure/Utils/FileUtils.cs
using Microsoft.AspNetCore.Http;
using System.IO;

namespace NetMaster.Infrastructure.Utils
{
    public static class FileUtils
    {
        public static byte[] ReadFileData(IFormFile file)
        {
            using MemoryStream memoryStream = new();
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}