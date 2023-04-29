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

namespace SystemSample1.cashierModule
{
    public partial class cashierInveotry2 : Form
    {

        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;

        public cashierInveotry2()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            viewItemList();
        }

        public void viewItemList()
        {
            int i = 0;

            dataGridView1.Rows.Clear();
            connect.Open();
            command = new SqlCommand("Select * from tblItem ", connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {


                i += 1;
                dataGridView1.Rows.Add(i, reader["itemID"].ToString(), reader["itemImage"], reader["itemName"].ToString(), reader["itemQyt"].ToString(), reader["itemStatus"].ToString());


            }
            reader.Close();
            connect.Close();
        }

    }

}
