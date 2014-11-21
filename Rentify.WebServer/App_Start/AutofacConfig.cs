using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Features.Variance;
using Autofac.Integration.WebApi;
using MediatR;
using Microsoft.Practices.ServiceLocation;
using Owin;

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

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterMediatr();
            builder.RegisterCommandHandlers();
            builder.RegisterQueryHandlers();

            container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Register the Autofac middleware FIRST, then the Autofac Web API middleware
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
        }

        private static void RegisterCommandHandlers(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .AsClosedTypesOf(typeof(IAsyncRequestHandler<,>))
                   .AsImplementedInterfaces();
        }

        private static void RegisterQueryHandlers(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .AsClosedTypesOf(typeof(IAsyncRequest<>))
                   .AsImplementedInterfaces();
        }

        private static void RegisterMediatr(this ContainerBuilder builder)
        {
            //Register MediatR
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();

            //CommonServiceLocator is used by MediatR
            var lazy = new Lazy<IServiceLocator>(() => new AutofacServiceLocator(container));
            var serviceLocatorProvider = new ServiceLocatorProvider(() => lazy.Value);
            builder.RegisterInstance(serviceLocatorProvider);
        }
    }
}