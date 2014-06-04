using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TDriven.Web.Startup))]
namespace TDriven.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
