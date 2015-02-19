using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NExtensions;
using Rentify.Core.Data;
using Rentify.Core.Domain;
using Rentify.Core.Results;

namespace Rentify.Core.QueryHandlers
{
    public class SiteQueryHandler : IAsyncRequestHandler<SiteQuery, IResult<RentifySite>>, IRequestHandler<SiteQuery, IResult<RentifySite>>
    {
        private readonly IRentifyDataFacade data;

        public SiteQueryHandler(IRentifyDataFacade data)
        {
            this.data = data;
        }

        public async Task<IResult<RentifySite>> Handle(SiteQuery message)
        {
            var siteUniqueIdIndex = await data.RetrieveSiteUniqueIdIndexAsync(message.SiteUniqueId);

            if (siteUniqueIdIndex == null)
                return AResultOf<RentifySite>.Failure(
                        "Can not find site with unique ID: {0}".FormatWith(message.SiteUniqueId));

            var userSettings = await data.RetrieveUserSettingsAsync(siteUniqueIdIndex.UserId);

            if (userSettings == null)
                return AResultOf<RentifySite>.Failure("Cannot find user for ID: {0}".FormatWith(siteUniqueIdIndex.UserId));

            var settings = userSettings.GetRentifySettings();

            var site = settings.Sites.SingleOrDefault(s => s.UniqueId == message.SiteUniqueId);
            
            if (site == null)
                return AResultOf<RentifySite>.Failure("Can not find site with unique ID: {0} associated with user: {1}".FormatWith(message.SiteUniqueId, siteUniqueIdIndex.UserId));

            return AResultOf<RentifySite>.Success(site);
        }

        IResult<RentifySite> IRequestHandler<SiteQuery, IResult<RentifySite>>.Handle(SiteQuery message)
        {
            var siteUniqueIdIndex = data.RetrieveSiteUniqueIdIndex(message.SiteUniqueId);

            if (siteUniqueIdIndex == null)
                return AResultOf<RentifySite>.Failure(
                        "Can not find site with unique ID: {0}".FormatWith(message.SiteUniqueId));

            var userSettings = data.RetrieveUserSettings(siteUniqueIdIndex.UserId);

            if (userSettings == null)
                return AResultOf<RentifySite>.Failure("Cannot find user for ID: {0}".FormatWith(siteUniqueIdIndex.UserId));

            var settings = userSettings.GetRentifySettings();

            var site = settings.Sites.SingleOrDefault(s => s.UniqueId == message.SiteUniqueId);

            if (site == null)
                return AResultOf<RentifySite>.Failure("Can not find site with unique ID: {0} associated with user: {1}".FormatWith(message.SiteUniqueId, siteUniqueIdIndex.UserId));

            return AResultOf<RentifySite>.Success(site);
        }
    }
}