using System.Collections.Generic;
using System.Web.Mvc;
using MediatR;
using Rentify.Core.QueryHandlers;

namespace Rentify.Sites.Filters
{
    public class RentifySiteActionFilter : ActionFilterAttribute
    {
        private IMediator mediatr;
        private IDictionary<string, string> themes = new Dictionary<string, string>
        {
            {"cerulean", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/cerulean/bootstrap.min.css"},
            {"cosmo", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/cosmo/bootstrap.min.css"},
            {"cyborg", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/cyborg/bootstrap.min.css"},
        };

        public RentifySiteActionFilter(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var result = mediatr.Send(new RentifySiteByUrlQuery(filterContext.HttpContext.Request.Url));

            var themeStyle = themes[result.ThemeId];

            filterContext.Controller.ViewBag.ThemeStyleCss = themeStyle;
        }
    }
}