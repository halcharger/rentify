using System;
using MediatR;
using Rentify.Core.Domain;
using Rentify.Core.Results;

namespace Rentify.Core.QueryHandlers
{
    public class RentifySiteByUrlQuery : IRequest<IResult<RentifySite>>
    {
        public RentifySiteByUrlQuery(Uri requestUri)
        {
            RequestUri = requestUri;
        }

        public Uri RequestUri { get; set; } 
    }
}