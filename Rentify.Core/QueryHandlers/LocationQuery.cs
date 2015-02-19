using MediatR;
using Rentify.Core.Domain;
using Rentify.Core.Results;

namespace Rentify.Core.QueryHandlers
{
    public class LocationQuery : IAsyncRequest<IResult<Location>>
    {
        public LocationQuery(string siteUniqueId)
        {
            SiteUniqueId = siteUniqueId;
        }

        public string SiteUniqueId { get; set; }
    }
}