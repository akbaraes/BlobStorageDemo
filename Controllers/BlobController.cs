using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlobStorageSample.Model;
using BlobStorageSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorageSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IBlobService blobService;

        public BlobController(IBlobService blobService)
        {
            this.blobService = blobService;
        }
        // GET: api/Blob
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await blobService.ListBlobsAsync());
        }

        // GET: api/Blob/5
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string name)
        {
            var content = await blobService.GetBlobInfoAsync(name);
            return File(content.Content, content.ContentType);
        }

        // POST: api/Blob
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UploadFileRequest request)
        {
            await blobService.UploadFileBlobAsync(request.FilePath, request.FileName);
            return Ok();
        }

        // PUT: api/Blob/5
        [HttpPost("UploadContentBlob")]
        public async Task<IActionResult> UploadContentBlob([FromBody] UploadContentRequest request)
        {
            await blobService.UploadContentBlobAsync(request.Content, request.FileName);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            await blobService.DeleteBlobAsync(name);
            return Ok();
        }
    }
}
