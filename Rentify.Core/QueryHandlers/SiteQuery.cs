using MediatR;
using Rentify.Core.Domain;
using Rentify.Core.Results;

namespace Rentify.Core.QueryHandlers
{
    public class SiteQuery : IAsyncRequest<IResult<RentifySite>>, IRequest<IResult<RentifySite>>
    {
        public SiteQuery(string siteUniqueId)
        {
            SiteUniqueId = siteUniqueId;
        }

        public string SiteUniqueId { get; set; }
    }
}