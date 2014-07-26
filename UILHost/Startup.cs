using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UILHost.Startup))]
namespace UILHost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
