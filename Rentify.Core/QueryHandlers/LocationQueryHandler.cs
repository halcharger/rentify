using System.Threading.Tasks;
using MediatR;
using Rentify.Core.Domain;
using Rentify.Core.Results;

namespace Rentify.Core.QueryHandlers
{
    public class LocationQueryHandler : IAsyncRequestHandler<LocationQuery, IResult<Location>>
    {
        private readonly IMediator mediatr;

        public LocationQueryHandler(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        public async Task<IResult<Location>> Handle(LocationQuery message)
        {
            var siteQuery = await mediatr.SendAsync(new SiteQuery(message.SiteUniqueId));

            if (siteQuery.IsFailure)
                return AResultOf<Location>.Failure(siteQuery.FailureMessage);

            return AResultOf<Location>.Success(siteQuery.Result.Property.Location);
        }
    }
}