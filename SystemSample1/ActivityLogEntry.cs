using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SystemSample1
{
    class ActivityLogEntry
    {



        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();


        // class na taga kolekta ng string name, string action sa buong system

        // data structure na list
        List<ActivityLogEntry> logEntries = new List<ActivityLogEntry>();
        public string UserName { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }

        // user time
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }

        public ActivityLogEntry(string userName, string action)
        {
            UserName = userName;
            Action = action;
            Timestamp = DateTime.Now;
        }

        /*
        public void Login()
        {
            StartTime = DateTime.Now;
        }


        public void Logout()
        {
            Duration = DateTime.Now - StartTime;
        }
        */
    }
}
