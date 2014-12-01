using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AdaptiveSystems.AspNetIdentity.OAuth;
using FluentValidation.WebApi;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Rentify.WebServer.Startup))]

namespace Rentify.WebServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            AutomapperConfig.Setup();
            AutofacConfig.Setup(config, app);//this must be run BEFORE app.UseWebApi(config) below

            StartupOptions.ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            FluentValidationModelValidatorProvider.Configure(config);

            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
