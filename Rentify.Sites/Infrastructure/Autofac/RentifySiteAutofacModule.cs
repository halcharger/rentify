using Autofac;
using Rentify.Sites.Infrastructure.Providers;

namespace Rentify.Sites.Infrastructure.Autofac
{
    public class RentifySiteAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SessionRentifySiteProvider>().As<IRentifySiteProvider>();
        }
    }
}