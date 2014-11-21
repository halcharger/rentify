using System.Collections.Generic;
using MediatR;
using Rentify.WebServer.Domain;

namespace Rentify.WebServer.QueryHandling
{
    public class MySitesQuery : IAsyncRequest<IEnumerable<RentifySite>>
    {
        public MySitesQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}