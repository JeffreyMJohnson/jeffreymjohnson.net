using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Personal_Site.Startup))]
namespace Personal_Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
