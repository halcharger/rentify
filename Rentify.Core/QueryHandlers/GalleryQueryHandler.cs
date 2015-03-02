using System.Threading.Tasks;
using MediatR;
using Rentify.Core.Domain;
using Rentify.Core.Results;

namespace Rentify.Core.QueryHandlers
{
    public class GalleryQueryHandler : IAsyncRequestHandler<GalleryQuery, IResult<Gallery>>
    {
        private readonly IMediator mediatr;

        public GalleryQueryHandler(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        public async Task<IResult<Gallery>> Handle(GalleryQuery message)
        {
            var siteQuery = await mediatr.SendAsync(new SiteQuery(message.SiteUniqueId));

            if (siteQuery.IsFailure)
                return AResultOf<Gallery>.Failure(siteQuery.FailureMessage);

            return AResultOf<Gallery>.Success(siteQuery.Result.Property.Gallery);
            
        }
    }
}