using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Rentify.Core;
using Rentify.Sites.Infrastructure.Autofac;

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
            builder.RegisterModule<RentifySiteAutofacModule>();

            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}