using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Rentify.WebServer.CommandHandlers;
using Rentify.WebServer.Domain;
using Rentify.WebServer.Models;
using Rentify.WebServer.Providers;
using Rentify.WebServer.QueryHandling;

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

        [HttpPost]
        [Route("api/mysites")]
        public async Task<IEnumerable<SiteViewModel>> GetMySites()
        {
            var query = new MySitesQuery(userProvider.UserId);
            var result = await mediatr.SendAsync(query);
            return result.MapTo<SiteViewModel>();
        }

        [HttpPost]
        [Route("api/mysites/add")]
        public async Task<ICommandResult> AddSite(SiteBindingModel model)
        {
            var command = new AddSiteCommand(model.UserId, model.MapTo<RentifySite>());
            return await mediatr.SendAsync(command);
        }
    }
}