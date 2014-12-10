using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rentify.Core.Data;
using Rentify.Core.Domain;

namespace Rentify.Core.QueryHandlers
{
    public class SitePagesQueryHandler : IAsyncRequestHandler<SitePagesQuery, IEnumerable<WebPage>>
    {
        private readonly IRentifyDataFacade data;

        public SitePagesQueryHandler(IRentifyDataFacade data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<WebPage>> Handle(SitePagesQuery message)
        {
            var userSettings = await data.RetrieveUserSettingsAsync(message.UserId);

            if (userSettings == null)
                return Enumerable.Empty<WebPage>();

            var settings = userSettings.GetRentifySettings();

            var site = settings.Sites.SingleOrDefault(s => s.UniqueId == message.SiteUniqueId);
            if (site == null)
                return Enumerable.Empty<WebPage>();

            return site.Pages;
        }
    }
}