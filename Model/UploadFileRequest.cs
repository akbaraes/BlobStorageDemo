using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobStorageSample.Model
{
    public class UploadFileRequest
    {
        public UploadFileRequest()
        {

        }
        public UploadFileRequest(string filePath, string fileName)
        {
            this.FilePath = FilePath;
            this.FileName = fileName;
        }
        public string FilePath { get; set; }

        public string FileName { get; set; }
    }
}
