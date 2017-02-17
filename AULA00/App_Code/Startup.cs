using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AULA00.Startup))]
namespace AULA00
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
