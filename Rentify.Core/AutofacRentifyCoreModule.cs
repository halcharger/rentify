using System;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Features.Variance;
using MediatR;
using Microsoft.Practices.ServiceLocation;
using Rentify.Core.Data;
using Rentify.Core.Data.TableStorage;

namespace Rentify.Core
{
    public class AutofacRentifyCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterCommandHandlers(builder);
            RegisterQueryHandlers(builder);

            builder.RegisterType<RentifyDataFacade>().As<IRentifyDataFacade>();
            builder.RegisterInstance(new RentifyTables());

        }

        private void RegisterCommandHandlers(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .AsClosedTypesOf(typeof(IAsyncRequestHandler<,>))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .AsClosedTypesOf(typeof(IRequestHandler<,>))
                   .AsImplementedInterfaces();

        }

        private void RegisterQueryHandlers(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .AsClosedTypesOf(typeof(IAsyncRequest<>))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                   .AsClosedTypesOf(typeof(IRequest<>))
                   .AsImplementedInterfaces();

        }
    }

    public static class AutofacExtensions
    {
        public static void RegisterMediatr(this ContainerBuilder builder, Func<IContainer> getContainer)
        {
            //Register MediatR
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();

            //CommonServiceLocator is used by MediatR
            var lazy = new Lazy<IServiceLocator>(() => new AutofacServiceLocator(getContainer()));
            var serviceLocatorProvider = new ServiceLocatorProvider(() => lazy.Value);
            builder.RegisterInstance(serviceLocatorProvider);
        }
    }
}