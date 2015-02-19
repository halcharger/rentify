using System.Collections.Generic;
using System.Web.Mvc;
using MediatR;
using Rentify.Core.QueryHandlers;
using Rentify.Sites.Infrastructure.Providers;
using Rentify.Sites.Infrastructure.Themes;

namespace Rentify.Sites.Filters
{
    public class RentifySiteActionFilter : ActionFilterAttribute
    {
        private readonly IMediator mediatr;
        private readonly IRentifySiteProvider rentifySiteProvider;
        
        public RentifySiteActionFilter(IMediator mediatr, IRentifySiteProvider rentifySiteProvider)
        {
            this.mediatr = mediatr;
            this.rentifySiteProvider = rentifySiteProvider;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (rentifySiteProvider.RentifySite == null)
            {
                var siteQuery = mediatr.Send(new RentifySiteByUrlQuery(filterContext.HttpContext.Request.Url));
                if (siteQuery.IsSuccess)
                    rentifySiteProvider.RentifySite = siteQuery.Result;
            }

            var site = rentifySiteProvider.RentifySite;

            if (site == null)
            {
                filterContext.Controller.ViewBag.SiteNotFoundUrl = filterContext.HttpContext.Request.Url.ToString();
                filterContext.HttpContext.Response.Redirect(string.Format("~/sitenotfound.html?from={0}",
                    filterContext.HttpContext.Request.Url));
            }
            else
            {
                var theme = ThemeFactory.CreateTheme(site.ThemeId);
                if (theme is UnknownTheme)
                    filterContext.HttpContext.Response.Redirect(string.Format("~/themenotfound.html?from={0}",
                        filterContext.HttpContext.Request.Url));
                else
                    filterContext.HttpContext.Session["Theme"] = theme;
            }

        }
    }
}