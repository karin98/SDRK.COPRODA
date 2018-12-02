using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SDRK.COPRODA.Startup))]
namespace SDRK.COPRODA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
