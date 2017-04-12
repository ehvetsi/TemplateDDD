using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TemplateDDD.UI.Mvc.Startup))]
namespace TemplateDDD.UI.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
