using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Rentify.WebServer.Models;
using Rentify.WebServer.QueryHandling;

namespace Rentify.WebServer.Controllers
{
    [Authorize]
    public class MySitesController : ApiController
    {
        private readonly IMediator mediatr;

        public MySitesController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpPost]
        [Route("api/mysites")]
        public async Task<IEnumerable<SiteModel>> GetMySites()
        {
            var result = await mediatr.SendAsync(new MySitesQuery("blah"));
            return result.MapTo<SiteModel>();
        }
    }
}