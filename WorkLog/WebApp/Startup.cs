using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Indpro.Attendance.WebApp.Startup))]
namespace Indpro.Attendance.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
