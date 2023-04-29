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
    public partial class user_list: Form
    {

        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;
        public user_list()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            User();
        }

        public void User()
        {

            int i = 0;

            datagridUser.Rows.Clear();
            connect.Open();
            command = new SqlCommand("Select * from tblUserAccount ", connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {


                i += 1;
                datagridUser.Rows.Add(i, reader["userID"].ToString(), reader["image"], reader["username"].ToString(), reader["role"].ToString());

            }
            reader.Close();
            connect.Close();

        }

        private void datagridHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                if (datagridUser.Columns[e.ColumnIndex].Name == "Show")
                {
                   
                }

                else if (datagridUser.Columns[e.ColumnIndex].Name == "Delete")
                {
                    if (MessageBox.Show("Do you want to delete this account ?", "Delete the record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        connect.Open();
                        command = new SqlCommand("delete from tblUserAccount where userID like '" + datagridUser[1, e.RowIndex].Value.ToString() + "'", connect);
                        command.ExecuteNonQuery();
                        connect.Close();
                        MessageBox.Show("The selected acount have been successfully deleted.", "Tea Hara", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        User();

                    }


                }

            }
        }
    }
}
