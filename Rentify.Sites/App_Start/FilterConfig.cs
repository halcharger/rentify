using System.Web.Mvc;
using MediatR;
using Rentify.Sites.Filters;
using Rentify.Sites.Infrastructure.Providers;

namespace Rentify.Sites
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, IMediator mediatr, IRentifySiteProvider rentifySiteProvider)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RentifySiteActionFilter(mediatr, rentifySiteProvider));
        }
    }
}
