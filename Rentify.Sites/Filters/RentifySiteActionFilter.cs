using System.Collections.Generic;
using System.Web.Mvc;
using MediatR;
using Rentify.Core.QueryHandlers;
using Rentify.Sites.Infrastructure.Providers;

namespace Rentify.Sites.Filters
{
    public class RentifySiteActionFilter : ActionFilterAttribute
    {
        private IMediator mediatr;
        private IRentifySiteProvider rentifySiteProvider;
        
        private IDictionary<string, string> themeLayoutFiles = new Dictionary<string, string>
        {
            {"lavilla", "~/Views/Shared/Themes/lavilla/_Layout.cshtml"}
        };

        public RentifySiteActionFilter(IMediator mediatr, IRentifySiteProvider rentifySiteProvider)
        {
            this.mediatr = mediatr;
            this.rentifySiteProvider = rentifySiteProvider;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (rentifySiteProvider.RentifySite == null)
                rentifySiteProvider.RentifySite = mediatr.Send(new RentifySiteByUrlQuery(filterContext.HttpContext.Request.Url));

            var site = rentifySiteProvider.RentifySite;

            if (site == null)
            {
                filterContext.Controller.ViewBag.SiteNotFoundUrl = filterContext.HttpContext.Request.Url.ToString();
                filterContext.HttpContext.Response.Redirect(string.Format("~/sitenotfound.html?from={0}",
                    filterContext.HttpContext.Request.Url));
            }
            else
            {
                if (themeLayoutFiles.ContainsKey(site.ThemeId))
                    filterContext.HttpContext.Session["ThemeLayoutFile"] = themeLayoutFiles[site.ThemeId];

                filterContext.HttpContext.Session["ThemeLayoutFile"] = "~/Views/Shared/Themes/lavilla/_Layout.cshtml";
            }

        }
    }
}