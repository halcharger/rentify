using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MediatR;
using Rentify.Sites.Infrastructure.Providers;

namespace Rentify.Sites
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.Setup();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, AutofacConfig.Resolve<IMediator>(), AutofacConfig.Resolve<IRentifySiteProvider>());//nasty!!
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
