using Microsoft.Owin;
using Owin;
using Notification_Signalr_Sqldependency;

[assembly: OwinStartup(typeof(Notification_Signalr_Sqldependency.Startup))]
namespace Notification_Signalr_Sqldependency
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}