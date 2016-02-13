using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuitarSite.Startup))]
namespace GuitarSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
