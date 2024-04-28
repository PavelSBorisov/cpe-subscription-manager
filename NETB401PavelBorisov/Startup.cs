using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NETB401PavelBorisov.Startup))]
namespace NETB401PavelBorisov
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
