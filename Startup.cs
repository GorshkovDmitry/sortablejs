using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectForDNS.Startup))]
namespace ProjectForDNS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
