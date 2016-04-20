using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Solutioneers.Startup))]
namespace Solutioneers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
