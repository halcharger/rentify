using System.Threading.Tasks;
using MediatR;
using Rentify.Core.Data;
using Rentify.Core.Domain;
using Rentify.Core.Results;

namespace Rentify.Core.QueryHandlers
{
    public class PropertyOverviewQueryHandler : IAsyncRequestHandler<PropertyOverviewQuery, IResult<PropertyOverview>>
    {
        private readonly IRentifyDataFacade data;
        private readonly IMediator mediatr;

        public PropertyOverviewQueryHandler(IRentifyDataFacade data, IMediator mediatr)
        {
            this.data = data;
            this.mediatr = mediatr;
        }

        public async Task<IResult<PropertyOverview>> Handle(PropertyOverviewQuery message)
        {
            var siteQuery = await mediatr.SendAsync(new SiteQuery(message.SiteUniqueId));

            if (siteQuery.IsFailure)
                return AResultOf<PropertyOverview>.Failure(siteQuery.FailureMessage);
            
            return AResultOf<PropertyOverview>.Success(siteQuery.Result.Property.Overview);
        }
    }
}