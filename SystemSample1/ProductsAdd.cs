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
    public partial class ProductsAdd : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;
        inventoryProduct frm;

        public ProductsAdd(inventoryProduct product)
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            frm = product;
        }

        public void Clear()
        {
            btnSave.Enabled = true;

            txtName.Clear();
            cmbCategory.Text = "";
            txtPrice.Clear();
            cmbStatus.Text = "";
            txtName.Focus();
           

            Graphics g = image1.CreateGraphics();
            g.Clear(Color.White);
            
            
        }

        // Product details save in database
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (MessageBox.Show("Save the product details? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    MemoryStream mstream = new MemoryStream();
                    image1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] selectImage = mstream.GetBuffer();


                    connect.Open();
                    command = new SqlCommand("insert into tblProduct(Image, Name, category, Price, Status, Deleted )VALUEs(@Image, @Name, @category, @Price, @Status, @Deleted)", connect);

                    command.Parameters.AddWithValue("@Image", selectImage);
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@category", cmbCategory.SelectedItem);
                    command.Parameters.AddWithValue("@Price", double.Parse(txtPrice.Text));
                    command.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem);
                    command.Parameters.AddWithValue("@Deleted", 0);
                    command.ExecuteNonQuery();
                    connect.Close();

                    MessageBox.Show("Successfully added!!!");
                    Clear();
              
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void LoadCategoryAdd()
        {
            cmbCategory.Items.Clear();

            connect.Open();
            command = new SqlCommand("SELECT * FROM tblCategory ", connect);
            reader = command.ExecuteReader();

            while (reader.Read())
            {

                //String name = reader.GetString(0);
                //cmbCategory.Items.Add(name);

                cmbCategory.Items.Add(reader[1].ToString());

            }
            reader.Close();
            connect.Close();

        }


        private void btnProductImage_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Image Files (*.png)|*.png|(*.jpg)|*.jpg|(*.gif)|*.gif";
                openFileDialog1.ShowDialog();
                image1.Image = Image.FromFile(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CategoryAdd cate = new CategoryAdd();

            cate.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
            Clear();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
               

            }else if (e.KeyChar == 8)
            {

            }
            else if((e.KeyChar<48) || (e.KeyChar > 57)) //ascii code 48-57 between 0-9
            {
                e.Handled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (MessageBox.Show("Save the new update product details? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if ((txtName.Text == string.Empty) || (cmbStatus.Text == string.Empty))
                    {
                        MessageBox.Show("Warning: Required empty field!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    MemoryStream mstream = new MemoryStream();
                    image1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] selectImage = mstream.ToArray();

                    using (SqlConnection connection = new SqlConnection(database.MyConnection()))
                    {
                        connection.Open();

                        string query = "UPDATE tblProduct SET Image = @Image, Name = @Name, category = @category, Price = @Price, Status = @Status WHERE productID = @productID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Image", selectImage);
                            command.Parameters.AddWithValue("@Name", txtName.Text);
                            command.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
                            command.Parameters.AddWithValue("@category", cmbCategory.SelectedItem);
                            command.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem);
                            command.Parameters.AddWithValue("@productID", Convert.ToInt32(txtID.Text));

                            command.ExecuteNonQuery();
                            command.ExecuteNonQuery();
                        }

                    }
                 
                   
                    connect.Close();
                    this.Dispose();
                    MessageBox.Show("Edit successfully");
                    frm.ViewProductList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
