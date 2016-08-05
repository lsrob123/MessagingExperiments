using Microsoft.Owin;
using Owin;
using SignalRApp.Web;

[assembly: OwinStartup(typeof (Startup))]

namespace SignalRApp.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}