using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SystemSample1
{
    public partial class historyLog : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;
        public historyLog()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            Log();
        }


        public void Log()
        {
           
            int i = 0;

            datagridHistory.Rows.Clear();
            connect.Open();
            command = new SqlCommand("Select * from tblActivityLog ", connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {


                i += 1;
                datagridHistory.Rows.Add(i, reader["ID"].ToString(), reader["user_name"], reader["action"].ToString(), reader["timestamp"].ToString());

            }
            reader.Close();
            connect.Close();
           
        }


    }
}
