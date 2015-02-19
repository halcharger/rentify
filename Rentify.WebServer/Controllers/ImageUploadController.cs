using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Rentify.Core.CommandHandlers;
using Rentify.Core.Data.BlobStorage;
using Rentify.Core.Domain;
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
            var aib = await Upload(siteUniqueId, "custommapimage");

            return Ok();
        }

        [Route("api/site/gallery/upload"), HttpPost]
        public async Task<IHttpActionResult> UploadGalleryImage(string siteUniqueId, string galleryId)
        {
            var imageName = Guid.NewGuid().ToString();

            var aib = await Upload(siteUniqueId, imageName);

            var result = await mediatr.SendAsync(new AddGalleryImageCommand(siteUniqueId, userProvider.UserId, galleryId, aib));

            if (result.IsFailure)
                return BadRequest(result.FailureMessage);

            return Ok();
        }

        protected async Task<AzureBlobImage> Upload(string siteUniqueId, string imageName)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            await uploadProcessor.ProcessUploadChunkRequest(Request);

            var blobName = string.Concat(imageName, ".", uploadProcessor.UploadedFileExtension());
            if (uploadProcessor.IsComplete)
            {
                using (var file = uploadProcessor.OpenTempFile())
                {
                    await blobStorage.UploadImageBlob(siteUniqueId, blobName, file);
                }

                //delete local temp file
                uploadProcessor.DeleteTempFile();
            }

            return new AzureBlobImage(siteUniqueId, blobName);
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