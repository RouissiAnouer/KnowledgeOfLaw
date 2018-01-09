using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RtfToHtml.Startup))]
namespace RtfToHtml
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
