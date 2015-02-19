using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using NExtensions;
using Rentify.Core.CommandHandlers;
using Rentify.Core.QueryHandlers;
using Rentify.WebServer.Extensions;
using Rentify.WebServer.Models;
using Rentify.WebServer.Providers;

namespace Rentify.WebServer.Controllers
{
    [Authorize]
    public class MySitesController : ApiController
    {
        private readonly IMediator mediatr;
        private readonly IUserProvider userProvider;

        public MySitesController(IMediator mediatr, IUserProvider userProvider)
        {
            this.mediatr = mediatr;
            this.userProvider = userProvider;
        }

        [HttpGet]
        [Route("api/mysites")]
        public async Task<IEnumerable<SiteViewModel>> Get()
        {
            var query = new MySitesQuery(userProvider.UserId);
            var result = await mediatr.SendAsync(query);
            return result.MapTo<SiteViewModel>();
        }

        [HttpPost]
        [Route("api/mysites/add")]
        public async Task<IHttpActionResult> Add(AddSiteBindingModel model)
        {
            if (ModelState.NotValid())
            {
                return BadRequest(ModelState);
            }

            var command = new AddSiteCommand(userProvider.UserId, model.Name, model.UniqueId);
            var result = await mediatr.SendAsync(command);

            if (result.IsFailure)
                return BadRequest(result.FailureMessage);

            return Ok();
        }

        [HttpDelete()]
        [Route("api/mysites/delete")]
        public async Task<IHttpActionResult> Delete(string uniqueId)
        {
            if (!uniqueId.HasValue())
                return BadRequest("You must provide a value for the parameter 'uniqueId'");

            var command = new DeleteSiteCommand(userProvider.UserId, uniqueId);
            var result = await mediatr.SendAsync(command);

            if (result.IsFailure)
                return BadRequest(result.FailureMessage);

            return Ok();
        }
    }
}