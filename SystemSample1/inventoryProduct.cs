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
using System.IO;

namespace SystemSample1
{
    public partial class inventoryProduct : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;
        
        
        string product_id, product_name, product_price, product_category, product_status;
        
        Image product_image;

        public inventoryProduct()
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductsAdd pro = new ProductsAdd(this);
            pro.btnUpdate.Enabled = false;
            pro.LoadCategoryAdd();
            pro.ShowDialog();
        }

        private void datagridProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string columnProduct = datagridProduct.Columns[e.ColumnIndex].Name;
            if(columnProduct == "Edit")
            {
                  ProductsAdd frm = new ProductsAdd(this);
                  frm.lblTitle.Text = "Update the product";
                  frm.LoadCategoryAdd();
                  frm.btnSave.Enabled = false;
                  frm.btnUpdate.Enabled = true;
                  frm.txtName.Text = product_name;
                  frm.txtID.Text = product_id;
                  frm.txtPrice.Text = product_price;
                  frm.cmbCategory.Text = product_category;
                  frm.cmbStatus.Text = product_status;
                  frm.image1.Image = product_image;
                  frm.ShowDialog();


            }

            else if (columnProduct == "Delete")
            {
                if (MessageBox.Show("Do you want to delete this product?", "Delete the record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (e.ColumnIndex == datagridProduct.Columns["Delete"].Index && e.RowIndex >= 0)
                    {
                        int id = Convert.ToInt32(datagridProduct.Rows[e.RowIndex].Cells["ID"].Value);
                        using (SqlConnection connection = new SqlConnection(database.MyConnection()))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand("UPDATE tblProduct SET Deleted = 1 WHERE productID = @productID", connection))
                            {
                                command.Parameters.AddWithValue("@productID", id);
                                command.ExecuteNonQuery();
                            }
                            connection.Close();
                        }
                        datagridProduct.Rows.RemoveAt(e.RowIndex);

                    }
                }
            }
            
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            Recycle recycle = new Recycle();
            recycle.ShowDialog();
        }

        private void datagridProduct_SelectionChanged(object sender, EventArgs e)
        {

            int i = datagridProduct.CurrentRow.Index;
            byte[] img = (byte[])datagridProduct.Rows[i].Cells["productImage"].Value;

            product_image = Image.FromStream(new MemoryStream(img));
            product_id = datagridProduct[1, i].Value.ToString();
            product_name = datagridProduct[3, i].Value.ToString();
            product_price = datagridProduct[5, i].Value.ToString();
            product_category = datagridProduct[4, i].Value.ToString();
            product_status = datagridProduct[6, i].Value.ToString();
           

        }
    }
}
