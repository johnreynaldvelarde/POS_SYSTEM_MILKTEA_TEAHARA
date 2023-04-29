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
    public partial class CategoryAdd : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
       // ProductsAdd add;
       // inventoryCategory addCate;

        public CategoryAdd()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            //  add = pro;
            ///addCate = inve;
            
        }
        public void categoryRefresh()
        {
            inventoryCategory category = new inventoryCategory();
            category.viewCategory();
        }

        public void Clear()
        {
            btnSave.Enabled = true;
            txtCategory.Clear();
            txtCategory.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCategory.Text == "")
            {
                MessageBox.Show("No Input Try Again!!!");
                Clear();
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Save this category? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        connect.Open();
                        command = new SqlCommand("INSERT INTo tblCategory(categoryName)VALUEs(@categoryName)", connect);
                        command.Parameters.AddWithValue("@categoryName", txtCategory.Text);
                        command.ExecuteNonQuery();
                        connect.Close();
                        MessageBox.Show("Successfully added!");
                        Clear();
                        
                      

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCategory.Clear();
            txtCategory.Focus();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }
    }
}
