using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Rentify.Core.QueryHandlers;
using Rentify.WebServer.Models;

namespace Rentify.WebServer.Controllers
{
    public class SiteQueriesController : ApiController
    {
        private readonly IMediator mediatr;

        public SiteQueriesController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        [Route("api/site/propertyoverview")]
        public async Task<IHttpActionResult> GetPropertyOverview(string siteUniqueId)
        {
            var query = await mediatr.SendAsync(new PropertyOverviewQuery(siteUniqueId));

            if (query.IsFailure)
                return BadRequest(query.FailureMessage);

            return Ok(query.Result.MapTo<PropertyOverviewViewModel>());
        }

        [HttpGet]
        [Route("api/site/location")]
        public async Task<IHttpActionResult> GetLocation(string siteUniqueId)
        {
            var query = await mediatr.SendAsync(new LocationQuery(siteUniqueId));

            if (query.IsFailure)
                return BadRequest(query.FailureMessage);

            return Ok(query.Result.MapTo<LocationViewModel>(siteUniqueId));
        }

        [HttpGet]
        [Route("api/site/gallery")]
        public async Task<IHttpActionResult> GetGallery(string siteUniqueId)
        {
            var query = await mediatr.SendAsync(new GalleryQuery(siteUniqueId));

            if (query.IsFailure)
                return BadRequest(query.FailureMessage);

            return Ok(query.Result.MapTo<GalleryViewModel>());
        }
    }
}