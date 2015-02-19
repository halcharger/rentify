using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rentify.Sites.Startup))]
namespace Rentify.Sites
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
