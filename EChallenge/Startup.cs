using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EChallenge.Startup))]
namespace EChallenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
