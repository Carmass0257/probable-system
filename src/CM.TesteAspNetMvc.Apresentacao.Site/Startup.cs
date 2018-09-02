using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CM.TesteAspNetMvc.Apresentacao.Site.Startup))]
namespace CM.TesteAspNetMvc.Apresentacao.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
