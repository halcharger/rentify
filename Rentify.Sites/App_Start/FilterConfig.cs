using System.Web.Mvc;
using MediatR;
using Rentify.Sites.Filters;

namespace Rentify.Sites
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, IMediator mediatr)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RentifySiteActionFilter(mediatr));
        }
    }
}
