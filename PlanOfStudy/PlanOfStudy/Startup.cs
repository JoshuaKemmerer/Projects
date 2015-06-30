using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlanOfStudy.Startup))]
namespace PlanOfStudy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
