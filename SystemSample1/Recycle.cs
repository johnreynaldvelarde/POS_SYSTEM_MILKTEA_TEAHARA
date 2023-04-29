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
    public partial class Recycle : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;
       
        public Recycle()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            showBin();
            datagridProduct.Refresh();
            
        }


        public void showBin()
        {
            int i = 0;
            datagridProduct.Rows.Clear();
            connect.Open();
            command = new SqlCommand("Select * from tblProduct WHERE Deleted = 1", connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Deleted"].ToString() == "1")
                {
                    i += 1;
                    datagridProduct.Rows.Add(i, reader["productID"].ToString(), reader["Image"], reader["Name"].ToString(), reader["category"].ToString(), reader["Price"].ToString(), reader["Status"].ToString());
                }
            }
            reader.Close();
            connect.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }   

        private void datagridProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnProduct = datagridProduct.Columns[e.ColumnIndex].Name;

            if (columnProduct == "Restore")
            {

                if (MessageBox.Show("Do you want to restore this product?", "Restore the record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (e.ColumnIndex == datagridProduct.Columns["Restore"].Index && e.RowIndex >= 0)
                    {
                        int id = Convert.ToInt32(datagridProduct.Rows[e.RowIndex].Cells["ID"].Value);
                        using (SqlConnection connection = new SqlConnection(database.MyConnection()))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand("UPDATE tblProduct SET Deleted = @Deleted WHERE productID = @productID", connection))
                            {
                                command.Parameters.AddWithValue("@productID", id);
                                command.Parameters.AddWithValue("@Deleted", 0);
                                command.ExecuteNonQuery();
                            }
                            connection.Close();
                        }
                        datagridProduct.Rows.RemoveAt(e.RowIndex);

                    }
                }

            }
            else if (columnProduct == "Delete")
            {
                if (MessageBox.Show("Are you sure to delete this permanently?", "Delete the record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connect.Open();
                    command = new SqlCommand("delete from tblProduct where productID like '" + datagridProduct[1, e.RowIndex].Value.ToString() + "'", connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("The selected record has been successfully deleted.", "Tea Hara", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showBin();
                    
                }
                
            }

        }
    }

}
