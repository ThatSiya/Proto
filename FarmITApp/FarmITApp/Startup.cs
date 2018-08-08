using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FarmITApp.Startup))]
namespace FarmITApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
