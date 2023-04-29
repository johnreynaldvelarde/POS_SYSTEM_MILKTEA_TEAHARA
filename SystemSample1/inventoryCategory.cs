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
    public partial class inventoryCategory : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;

        public inventoryCategory()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            viewCategory();
        }

        public void viewCategory()
        {
            int i = 0;

            datagridCategory.Rows.Clear();
            connect.Open();
            command = new SqlCommand("Select * from tblCategory ", connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {


                i += 1;
                datagridCategory.Rows.Add(i, reader["categoryID"].ToString(), reader["categoryName"].ToString());


            }
            reader.Close();
            connect.Close();
        }

        private void datagridCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnCategory = datagridCategory.Columns[e.ColumnIndex].Name;
            
            if (columnCategory == "Delete")
            {
                if (MessageBox.Show("Do you want to delete this category?", "Delete the record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connect.Open();
                    command = new SqlCommand("Delete from tblCategory where categoryID like '" + datagridCategory[1, e.RowIndex].Value.ToString() + "'", connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("The selected category have been successfully deleted.", "Tea Hara", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    viewCategory();

                }

            }
        }

        private void btnaddCategory_Click(object sender, EventArgs e)
        {
            CategoryAdd cate = new CategoryAdd();

            cate.ShowDialog();
        }
    }
}
