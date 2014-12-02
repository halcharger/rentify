using System.Linq;
using MediatR;
using Rentify.Core.Data;
using Rentify.Core.Domain;
using Rentify.Core.Exceptions;
using Rentify.Core.Extensions;

namespace Rentify.Core.QueryHandlers
{
    public class RentifySiteByUrlQueryHandler : IRequestHandler<RentifySiteByUrlQuery, RentifySite>
    {
        private readonly IRentifyDataFacade data;

        public RentifySiteByUrlQueryHandler(IRentifyDataFacade data)
        {
            this.data = data;
        }

        public RentifySite Handle(RentifySiteByUrlQuery message)
        {
            var siteUniqueId = message.RequestUri.GetRentifyUniqueSiteId();
            var index = data.RetrieveSiteUniqueIdIndex(siteUniqueId);

            if (index == null)
                throw new SiteNotFoundException(message.RequestUri);

            var userSetting = data.RetrieveUserSettings(index.UserId);
            return userSetting.GetRentifySettings().Sites.SingleOrDefault(s => s.UniqueId == siteUniqueId);
        }

    }
}