using System.Configuration;
using System.Web.Http;
using AdaptiveSystems.AspNetIdentity.OAuth;
using FluentValidation.WebApi;
using log4net.Config;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Rentify.WebServer;

[assembly: OwinStartup(typeof(Startup))]

namespace Rentify.WebServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            AutoMapperConfig.Setup();
            AutofacConfig.Setup(config, app);//this must be run BEFORE app.UseWebApi(config) below

            StartupOptions.ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);

            //redirect everything that isn't a WebApi route through to index.html (SPA staring point)
            config.Routes.MapHttpRoute(
                name: "spa-route",
                routeTemplate: "{*anything}",
                defaults: "~/index.html"
                );

            FluentValidationModelValidatorProvider.Configure(config);

            XmlConfigurator.Configure();
        }
    }
}
