using System.Collections.Generic;
using MediatR;
using Rentify.Core.Results;

namespace Rentify.Core.QueryHandlers
{
    public class GalleryImageUrlsQuery : IAsyncRequest<IResult<IEnumerable<string>>>
    {
        public GalleryImageUrlsQuery(string siteUniqueId, string galleryId)
        {
            SiteUniqueId = siteUniqueId;
            GalleryId = galleryId;
        }

        public string SiteUniqueId { get; set; }
        public string GalleryId { get; set; }
    }
}