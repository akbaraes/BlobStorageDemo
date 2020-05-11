using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BlobStorageSample.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobStorageSample.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient blobServiceClient;
        private readonly BlobContainerClient blobContainerClient;
        public BlobService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
            this.blobContainerClient = this.blobServiceClient.GetBlobContainerClient("youtube");
        }

        public async Task DeleteBlobAsync(string name)
        {
            var blobClient = this.blobContainerClient.GetBlobClient(name);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<Model.BlobContentInfo> GetBlobInfoAsync(string name)
        {
            var blobClient = this.blobContainerClient.GetBlobClient(name);
            var content = await blobClient.DownloadAsync();
            return new Model.BlobContentInfo(content.Value.Content, content.Value.ContentType);
        }

        public async Task<IEnumerable<string>> ListBlobsAsync()
        {
            var items = new List<string>();

            await foreach (var item in blobContainerClient.GetBlobsAsync())
            {
                items.Add(item.Name);
            }

            return items;
        }

        public async Task UploadContentBlobAsync(string content, string fileName)
        {
            var blobClient = this.blobContainerClient.GetBlobClient(fileName);
            var bytes = Encoding.UTF8.GetBytes(content);
            using var memeoryStream = new MemoryStream(bytes);
            await blobClient.UploadAsync(memeoryStream, new BlobHttpHeaders() { ContentType = fileName.GetContentType() });
        }

        public async Task UploadFileBlobAsync(string filepath, string fileName)
        {
            var blobClient = this.blobContainerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(filepath, new BlobHttpHeaders() { ContentType = filepath.GetContentType() });
        }
    }
}
