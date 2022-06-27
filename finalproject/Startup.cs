using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(finalproject.Startup))]
namespace finalproject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
