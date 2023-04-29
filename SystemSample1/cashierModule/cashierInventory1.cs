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
    public partial class cashierInventory1 : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;

        public cashierInventory1()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            ViewProductList();
        }

        public void ViewProductList()
        {
            int i = 0;
            //order by productID, Image, Name, category, Price, Quantity, Status"

            datagridProduct.Rows.Clear();
            connect.Open();
            command = new SqlCommand("Select * from tblProduct WHERE Deleted = 0", connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Deleted"].ToString() == "0")
                {
                    i += 1;
                    datagridProduct.Rows.Add(i, reader["productID"].ToString(), reader["Image"], reader["Name"].ToString(), reader["category"].ToString(), reader["Price"].ToString(), reader["Status"].ToString());
                }
            }
            reader.Close();
            connect.Close();

        }
    }
}
