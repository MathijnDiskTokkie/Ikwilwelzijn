using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ikkanwelzijn.Startup))]
namespace Ikkanwelzijn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
