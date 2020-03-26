using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaseManagement.Startup))]
namespace CaseManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
