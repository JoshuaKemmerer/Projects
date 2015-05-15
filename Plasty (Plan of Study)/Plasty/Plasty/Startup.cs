using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Plasty.Startup))]
namespace Plasty
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
