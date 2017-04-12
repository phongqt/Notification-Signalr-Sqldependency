using DAL.Models;
using Notification_Signalr_Sqldependency.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Notification_Signalr_Sqldependency.Controllers
{
    public class APINotificationController : ApiController
    {
        NotificationRepository objRepo = new NotificationRepository();

        // GET api/values
        public IEnumerable<Notification> Get()
        {
            return objRepo.GetData();
        }
    }
}
