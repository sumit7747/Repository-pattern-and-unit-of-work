using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnitofWork.Startup))]
namespace UnitofWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
