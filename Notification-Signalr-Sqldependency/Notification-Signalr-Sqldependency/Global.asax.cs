using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Notification_Signalr_Sqldependency
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["NotificationSignalR"].ConnectionString);            
        }


        protected void Application_End()
        {
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["NotificationSignalR"].ConnectionString);
        }
    }
}
