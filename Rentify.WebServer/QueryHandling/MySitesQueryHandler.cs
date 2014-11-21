using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rentify.WebServer.Domain;

namespace Rentify.WebServer.QueryHandling
{
    public class MySitesQueryHandler : IAsyncRequestHandler<MySitesQuery, IEnumerable<RentifySite>>
    {
        public Task<IEnumerable<RentifySite>> Handle(MySitesQuery message)
        {
            return Task.FromResult(new[] { new RentifySite { Name = "some name", UniqueId = Guid.NewGuid().ToString() } }.AsEnumerable());
        }
    }
}