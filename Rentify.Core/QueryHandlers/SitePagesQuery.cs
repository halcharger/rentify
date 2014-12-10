using System.Collections.Generic;
using MediatR;
using Rentify.Core.Domain;

namespace Rentify.Core.QueryHandlers
{
    public class SitePagesQuery : IAsyncRequest<IEnumerable<WebPage>>
    {
        public SitePagesQuery(string userId, string siteUniqueId)
        {
            UserId = userId;
            SiteUniqueId = siteUniqueId;
        }

        public string UserId { get; set; }
        public string SiteUniqueId { get; set; }
    }
}