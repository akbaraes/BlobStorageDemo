using BlobStorageSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobStorageSample.Services
{
    public interface IBlobService
    {

        Task<BlobContentInfo> GetBlobInfoAsync(string name);

        Task<IEnumerable<string>> ListBlobsAsync();

        Task UploadFileBlobAsync(string filepath, string fileName);

        Task UploadContentBlobAsync(string content, string fileName);

        Task DeleteBlobAsync(string name);

    }
}
