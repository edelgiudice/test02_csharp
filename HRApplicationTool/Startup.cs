using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRApplicationTool.Startup))]
namespace HRApplicationTool
{
    public partial class Startup
    {
        // Config
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
