using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookSite.Startup))]
namespace BookSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
