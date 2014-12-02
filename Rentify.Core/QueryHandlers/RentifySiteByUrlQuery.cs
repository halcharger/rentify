using System;
using MediatR;
using Rentify.Core.Domain;

namespace Rentify.Core.QueryHandlers
{
    public class RentifySiteByUrlQuery : IRequest<RentifySite>
    {
        public RentifySiteByUrlQuery(Uri requestUri)
        {
            RequestUri = requestUri;
        }

        public Uri RequestUri { get; set; } 
    }
}