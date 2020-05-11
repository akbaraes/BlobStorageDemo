using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobStorageSample.Model
{
    public class UploadContentRequest
    {
        public UploadContentRequest()
        {

        }
        public UploadContentRequest(string content,string fileName)
        {
            this.Content = content;
            this.FileName = fileName;
        }
        public string Content { get; set; }

        public string FileName { get; set; }
    }
}
