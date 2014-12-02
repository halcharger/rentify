using System.Collections.Generic;
using MediatR;
using Rentify.Core.Domain;

namespace Rentify.Core.QueryHandlers
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