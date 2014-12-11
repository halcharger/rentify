using System.Collections.Generic;
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
    public class WebPagesController : ApiController
    {
        private readonly IMediator mediatr;
        private readonly IUserProvider userProvider;

        public WebPagesController(IMediator mediatr, IUserProvider userProvider)
        {
            this.mediatr = mediatr;
            this.userProvider = userProvider;
        }

        [HttpPost]
        [Route("api/{siteUniqueId}/pages")]
        public async Task<IEnumerable<PageViewModel>> Get(string siteUniqueId)
        {
            var query = new SitePagesQuery(userProvider.UserId, siteUniqueId);
            var result = await mediatr.SendAsync(query);
            return result.MapTo<PageViewModel>();
        }

        [HttpPost]
        [Route("api/{siteUniqueId}/save")]
        public async Task<IHttpActionResult> Save(string siteUniqueId, PageBindingModel model)
        {
            if (ModelState.NotValid())
            {
                return BadRequest(new FailureResult(ModelState).FailureMessage);
            }

            var command = new SaveWebPageCommand(userProvider.UserId, siteUniqueId, model.MapTo<WebPage>());
            var result = await mediatr.SendAsync(command);

            if (result.IsFailure)
                return BadRequest(result.FailureMessage);

            return Ok(result.Result);
        }

        [HttpDelete()]
        [Route("api/{siteUniqueId}/delete")]
        public async Task<IHttpActionResult> Delete(string siteUniqueId, int webPageId)
        {
            if (webPageId == 0)
                return BadRequest("You must provide a value for the parameter 'uniqueId'");

            var command = new DeleteWebPageCommand(userProvider.UserId, siteUniqueId, webPageId);
            var result = await mediatr.SendAsync(command);

            if (result.IsFailure)
                return BadRequest(result.FailureMessage);

            return Ok();
        }

    }
}