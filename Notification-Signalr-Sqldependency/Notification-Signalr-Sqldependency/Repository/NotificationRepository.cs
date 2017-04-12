using DAL.Models;
using Notification_Signalr_Sqldependency.Hubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification_Signalr_Sqldependency.Repository
{
    public class NotificationRepository
    {
        public IEnumerable<Notification> GetData()
        {

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NotificationSignalR"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT ID, Text, UserID, CreatedDate
               FROM [dbo].[NotificationList]", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var reader = command.ExecuteReader())
                        return reader.Cast<IDataRecord>()
                            .Select(x => new Notification()
                            {
                                ID = x.GetInt32(0),
                                Text = x.GetString(1),
                                UserID = x.GetString(2)
                            }).ToList();



                }
            }
        }
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            NotificationHub.Show();
        }
    }
}
