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
            {"darkly", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/darkly/bootstrap.min.css"},
            {"flatly", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/flatly/bootstrap.min.css"},
            {"journal", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/journal/bootstrap.min.css"},
            {"lumen", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/lumen/bootstrap.min.css"},
            {"paper", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/paper/bootstrap.min.css"},
            {"readable", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/readable/bootstrap.min.css"},
            {"sandstone", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/sandstone/bootstrap.min.css"},
            {"simplex", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/simplex/bootstrap.min.css"},
            {"slate", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/slate/bootstrap.min.css"},
            {"spacelab", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/spacelab/bootstrap.min.css"},
            {"superhero", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/superhero/bootstrap.min.css"},
            {"united", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/united/bootstrap.min.css"},
            {"yeti", "//maxcdn.bootstrapcdn.com/bootswatch/3.3.0/yeti/bootstrap.min.css"},
        };

        public RentifySiteActionFilter(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var result = mediatr.Send(new RentifySiteByUrlQuery(filterContext.HttpContext.Request.Url));

            if (result == null)
            {
                filterContext.Controller.ViewBag.SiteNotFoundUrl = filterContext.HttpContext.Request.Url.ToString();
                filterContext.HttpContext.Response.Redirect(string.Format("~/sitenotfound.html?from={0}", filterContext.HttpContext.Request.Url));
            }

            filterContext.Controller.ViewBag.ThemeStyleCss = themes[result.ThemeId];
            filterContext.Controller.ViewBag.SiteName = result.Name;
        }
    }
}