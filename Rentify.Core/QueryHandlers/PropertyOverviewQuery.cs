using MediatR;
using Rentify.Core.Domain;
using Rentify.Core.Results;

namespace Rentify.Core.QueryHandlers
{
    public class PropertyOverviewQuery : IAsyncRequest<IResult<PropertyOverview>>
    {
        public PropertyOverviewQuery(string siteUniqueId)
        {
            SiteUniqueId = siteUniqueId;
        }

        public string SiteUniqueId { get; set; }
    }
}