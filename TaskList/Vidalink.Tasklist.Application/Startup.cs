using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidalink.Tasklist.Application.Startup))]
namespace Vidalink.Tasklist.Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
