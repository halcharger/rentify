using System.Threading.Tasks;
using MediatR;
using Rentify.Core.Domain;
using Rentify.Core.Extensions;
using Rentify.Core.Results;

namespace Rentify.Core.QueryHandlers
{
    public class RentifySiteByUrlQueryHandler : IRequestHandler<RentifySiteByUrlQuery, IResult<RentifySite>>
    {
        private readonly IMediator mediatr;

        public RentifySiteByUrlQueryHandler(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        public IResult<RentifySite> Handle(RentifySiteByUrlQuery message)
        {
            var siteUniqueId = message.RequestUri.GetRentifyUniqueSiteId();

            return mediatr.Send(new SiteQuery(siteUniqueId));
        }

    }
}