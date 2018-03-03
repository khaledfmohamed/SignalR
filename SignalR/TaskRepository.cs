using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SignalR
{
    public class TaskRepository
    {
        readonly string _connString =
        ConfigurationManager.ConnectionStrings["SqlServerModel"].ConnectionString;

        public List<Task> GetProgress()
        {
            SqlDependency dependency;
            var messages = new List<Task>();
            using (SignalRDbContext db = new SignalRDbContext())
            {
                db.Database.Connection.Open();
                DbCommand command = db.Database.Connection.CreateCommand();
                command.CommandText = db.Task.Sql;
                dependency = new  SqlDependency((SqlCommand)command);
                
                dependency.OnChange += new OnChangeEventHandler(DependencyOnChange);
               var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    messages.Add(item: new Task
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Progress = int.Parse(reader["Progress"].ToString()) 
                    });
                }
                db.Database.Connection.Close();
            }
            return messages;
        }

        void DependencyOnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency dependency = sender as SqlDependency;
            dependency.OnChange -= DependencyOnChange;
           
            if (e.Type == SqlNotificationType.Change)
            {
                TaskHub.SendMessages();
            }
        }
    }
}