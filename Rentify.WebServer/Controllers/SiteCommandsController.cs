using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Rentify.Core.CommandHandlers;
using Rentify.Core.Domain;
using Rentify.Core.QueryHandlers;
using Rentify.WebServer.Extensions;
using Rentify.WebServer.Models;
using Rentify.WebServer.Providers;

namespace Rentify.WebServer.Controllers
{
    [Authorize]
    public class SiteCommandsController : ApiController
    {
        private readonly IMediator mediatr;
        private readonly IUserProvider userProvider;

        public SiteCommandsController(IMediator mediatr, IUserProvider userProvider)
        {
            this.mediatr = mediatr;
            this.userProvider = userProvider;
        }

        [HttpPost]
        [Route("api/site/updatetheme")]
        public async Task<IHttpActionResult> UpdateTheme(UpdateSiteThemeBindingModel model)
        {
            var command = new UpdateSiteThemeCommand(userProvider.UserId, model.UniqueId, model.ThemeId);
            return await UpdateSiteComponent(command);
        }

        [HttpPost]
        [Route("api/site/updatepropertyoverview")]
        public async Task<IHttpActionResult> UpdatePropertyOverview(UpdatePropertyOverviewBindingModel model)
        {
            var command = new UpdatePropertyOverviewCommand(userProvider.UserId, model.UniqueId, model.MapTo<PropertyOverview>());
            return await UpdateSiteComponent(command);
        }

        [HttpPost]
        [Route("api/site/updategallery")]
        public async Task<IHttpActionResult> UpdateGallery(UpdatePropertyGalleryBindingModel model)
        {
            var command = new UpdatePropertyGalleryCommand(userProvider.UserId, model.UniqueId, model.MapTo<Gallery>());
            return await UpdateSiteComponent(command);
        }

        [HttpPost]
        [Route("api/site/removegalleryimage")]
        public async Task<IHttpActionResult> RemoveGalleryImage(RemoveGalleryImageBindingModel model)
        {
            var command = new RemoveGalleryImageCommand(userProvider.UserId, model.SiteUniqueId, model.GalleryId, model.ImageUrl);
            return await UpdateSiteComponent(command);
        }

        [HttpPost]
        [Route("api/site/updatelocation")]
        public async Task<IHttpActionResult> UpdateLocation(UpdateLocationBindingModel model)
        {
            var command = new UpdateLocationCommand(userProvider.UserId, model.UniqueId, model.MapTo<Location>());
            return await UpdateSiteComponent(command);
        }

        protected async Task<IHttpActionResult> UpdateSiteComponent(UpdateSiteComponentBaseCommand command)
        {
            if (ModelState.NotValid())
            {
                return BadRequest(ModelState);
            }

            var result = await mediatr.SendAsync(command);

            if (result.IsFailure)
                return BadRequest(result.FailureMessage);

            return Ok();
        }

    }
}