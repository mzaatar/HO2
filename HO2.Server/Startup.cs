using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HO2.Server.Startup))]

namespace HO2.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
