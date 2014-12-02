using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MediatR;
using Rentify.Core;

namespace Rentify.Sites
{
    public static class AutofacConfig
    {
        private static IContainer container;

        public static void Setup()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<AutofacRentifyCoreModule>();
            builder.RegisterMediatr(() => container);//a bit hacky I know.
            builder.RegisterControllers(typeof (MvcApplication).Assembly);
            builder.RegisterFilterProvider();

            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static IMediator GetIMediator()
        {
            return container.Resolve<IMediator>();
        }
    }
}