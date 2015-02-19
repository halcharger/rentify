using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Rentify.Core.CommandHandlers;
using Rentify.Core.Data.BlobStorage;
using Rentify.WebServer.FlowJs;
using Rentify.WebServer.Providers;

namespace Rentify.WebServer.Controllers
{
    [Authorize]
    public class ImageUploadController : ApiController
    {
        private readonly IMediator mediatr;
        private readonly IUserProvider userProvider;
        private readonly IFlowUploadProcessor uploadProcessor;
        private readonly IRentifyBlobStorageFacade blobStorage; 

        public ImageUploadController(IFlowUploadProcessor uploadProcessor, IRentifyBlobStorageFacade blobStorage, IMediator mediatr, IUserProvider userProvider)
        {
            this.uploadProcessor = uploadProcessor;
            this.blobStorage = blobStorage;
            this.mediatr = mediatr;
            this.userProvider = userProvider;
        }

        [Route("api/site/mapimage/upload"), HttpPost]
        public async Task<IHttpActionResult> UploadCustomMapImage(string siteUniqueId)
        {
            return await Upload(siteUniqueId, blobStorage.UploadCustomMapImageBlob);
        }

        [Route("api/site/gallery/upload"), HttpPost]
        public async Task<IHttpActionResult> UploadGalleryImage(string siteUniqueId, string galleryId)
        {
            var imageName = Guid.NewGuid().ToString();

            var result = await mediatr.SendAsync(new AddGalleryImageCommand(siteUniqueId, userProvider.UserId, galleryId, imageName));

            if (result.IsFailure)
                return BadRequest(result.FailureMessage);

            return await Upload(siteUniqueId, async (sui, file) => await blobStorage.UploadGalleryImageBlob(sui, imageName, file));
        }

        protected async Task<IHttpActionResult> Upload(string siteUniqueId, Func<string, FileStream, Task> uploadBlob)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            await uploadProcessor.ProcessUploadChunkRequest(Request);

            if (uploadProcessor.IsComplete)
            {
                using (var fileStream = uploadProcessor.OpenTempFile())
                {
                    await uploadBlob(siteUniqueId, fileStream);
                }

                //delete local temp file
                uploadProcessor.DeleteTempFile();
            }

            return Ok();
        }

        [Route("api/site/mapimage/upload"), 
        Route("api/site/gallery/upload"), 
        HttpGet]
        public IHttpActionResult TestFlowChunk([FromUri]FlowMetaData flowMeta)
        {
            //Debug.WriteLine("TEsting flow chunk...");
            //if (FlowUploadProcessor.HasRecievedChunk(flowMeta))
            //{
            //    return Ok();
            //}

            return NotFound();
        }
    }
}