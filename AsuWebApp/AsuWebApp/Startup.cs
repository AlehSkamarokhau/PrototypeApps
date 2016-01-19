using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsuWebApp.Startup))]
namespace AsuWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
