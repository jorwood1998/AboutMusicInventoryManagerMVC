using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AboutMusicInventoryManagerMVC.Startup))]
namespace AboutMusicInventoryManagerMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
