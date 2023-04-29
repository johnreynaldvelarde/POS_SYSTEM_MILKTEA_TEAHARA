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
    public partial class Notification : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;
        public Notification()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            notification();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void notification()
        {

            int i = 0;

            datagridHistory.Rows.Clear();
            connect.Open();
            command = new SqlCommand("Select * from tblNotification ", connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {

                i += 1;
                datagridHistory.Rows.Add(i, reader["noti_name"], reader["noti_action"].ToString(), reader["noti_time"].ToString());

            }
            reader.Close();
            connect.Close();

        }

        private void datagridHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnCategory = datagridHistory.Columns[e.ColumnIndex].Name;

            if (columnCategory == "Exit")
            {
                connect.Open();
                command = new SqlCommand("delete from tblNotification where ID like '" + datagridHistory[1, e.RowIndex].Value.ToString() + "'", connect);
                command.ExecuteNonQuery();
                connect.Close();
                notification();

            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(database.MyConnection()))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM tblNotification", connection))
                {
                    command.ExecuteNonQuery();
                }

            }
            notification();
        }
    }
}
