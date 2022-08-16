using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HMSII.Startup))]
namespace HMSII
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
