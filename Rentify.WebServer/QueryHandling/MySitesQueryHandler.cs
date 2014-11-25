using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rentify.WebServer.Data;
using Rentify.WebServer.Domain;

namespace Rentify.WebServer.QueryHandling
{
    public class MySitesQueryHandler : IAsyncRequestHandler<MySitesQuery, IEnumerable<RentifySite>>
    {
        private readonly IRentifyDataFacade data;

        public MySitesQueryHandler(IRentifyDataFacade data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<RentifySite>> Handle(MySitesQuery message)
        {
            var userSettings = await data.RetrieveUserSettingsAsync(message.UserId);

            return userSettings == null 
                ? Enumerable.Empty<RentifySite>() 
                : userSettings.GetRentifySettings().Sites;
        }
    }
}