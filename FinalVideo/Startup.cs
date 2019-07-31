using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalVideo.Startup))]
namespace FinalVideo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
