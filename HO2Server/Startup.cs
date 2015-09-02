using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HO2Server.Startup))]

namespace HO2Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
