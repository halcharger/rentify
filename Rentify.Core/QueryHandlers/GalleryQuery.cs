using MediatR;
using Rentify.Core.Domain;
using Rentify.Core.Results;

namespace Rentify.Core.QueryHandlers
{
    public class GalleryQuery : IAsyncRequest<IResult<Gallery>>
    {
        public GalleryQuery(string siteUniqueId)
        {
            SiteUniqueId = siteUniqueId;
        }

        public string SiteUniqueId { get; set; }
    }
}