using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobStorageSample.Services
{
    public static class FileExtension
    {
        public static readonly FileExtensionContentTypeProvider provider = new FileExtensionContentTypeProvider();

        public static string GetContentType(this string filepath)
        {
            if(!provider.TryGetContentType(filepath,out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }
    }
}
