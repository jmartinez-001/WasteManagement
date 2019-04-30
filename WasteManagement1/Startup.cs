using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WasteManagement1.Startup))]
namespace WasteManagement1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
