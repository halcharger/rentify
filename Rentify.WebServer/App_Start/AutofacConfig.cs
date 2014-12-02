using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using Rentify.Core;
using Rentify.WebServer.Providers;

namespace Rentify.WebServer
{
    public static class AutofacConfig
    {
        private static IContainer container;

        // Read the autofac documentation for more info on registering autofac middleware in OWIN:
        // http://autofac.readthedocs.org/en/latest/integration/webapi.html?highlight=webapi2
        // http://autofac.readthedocs.org/en/latest/integration/owin.html
        //
        public static void Setup(HttpConfiguration config, IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<AutofacRentifyCoreModule>();
            builder.RegisterMediatr(() => container);//a bit hacky I know.

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UserProvider>().As<IUserProvider>();

            container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Register the Autofac middleware FIRST, then the Autofac Web API middleware
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
        }

    }
}