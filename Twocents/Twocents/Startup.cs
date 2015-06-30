using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Twocents.Startup))]
namespace Twocents
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
