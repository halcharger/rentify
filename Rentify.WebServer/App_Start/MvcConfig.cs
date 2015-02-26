using System.Web.Mvc;
using System.Web.Routing;

namespace Rentify.WebServer
{
    public class MvcConfig
    {
        public static void RegisterMvcRoutes(RouteCollection routes)
        {
            //redirect everything that isn't a WebApi route through to index.html (SPA staring point)
            routes.MapRoute(
                name: "spa-route",
                url: "{*any}",
                defaults: new { controller = "Home", action = "Index" }
                );
        }
    }
}