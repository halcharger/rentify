using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using NExtensions;
using Rentify.Core.Results;

namespace Rentify.Core.QueryHandlers
{
    public class GalleryImageUrlsQueryHandler : IAsyncRequestHandler<GalleryImageUrlsQuery, IResult<IEnumerable<string>>>
    {
        private readonly IMediator mediatr;

        public GalleryImageUrlsQueryHandler(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        public async Task<IResult<IEnumerable<string>>> Handle(GalleryImageUrlsQuery message)
        {
            var siteQuery = await mediatr.SendAsync(new SiteQuery(message.SiteUniqueId));

            if (siteQuery.IsFailure)
                return AResultOf<IEnumerable<string>>.Failure(siteQuery.FailureMessage);

            var site = siteQuery.Result;

            if (site.Gallery.Id != message.GalleryId)
                return AResultOf<IEnumerable<string>>.Failure("Could not find a gallery in the site with the specified ID: {0}".FormatWith(message.GalleryId));

            return AResultOf<IEnumerable<string>>.Success(site.Gallery.ImageUrls);

        }
    }
}