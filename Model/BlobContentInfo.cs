using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlobStorageSample.Model
{
    public class BlobContentInfo
    {
        public BlobContentInfo()
        {

        }
        public BlobContentInfo(Stream content, string contentType)
        {
            this.Content = content;
            this.ContentType = contentType;
        }
        public Stream Content { get; set; }

        public string ContentType { get; set; }
    }
}
