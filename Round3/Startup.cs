using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Round3.Startup))]
namespace Round3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
