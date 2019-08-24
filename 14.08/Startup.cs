using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_14._08.Startup))]
namespace _14._08
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
