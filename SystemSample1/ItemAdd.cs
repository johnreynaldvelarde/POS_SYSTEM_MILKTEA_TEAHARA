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
    public partial class ItemAdd : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        inventoryItem frm;

        
        public ItemAdd(inventoryItem item)
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            frm = item;
            
        }

        public void Clear()
        {
            btnSave.Enabled = true;

            txtName.Clear();
            cmbStatus.Text = "";
            txtName.Focus();
            Graphics g = image1.CreateGraphics();
            g.Clear(Color.White);
        }   


        private void btnSave_Click(object sender, EventArgs e)
        {
            int itemId;

            try
            {
                if (MessageBox.Show("Save the item details? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if ((txtName.Text == string.Empty) || (cmbStatus.Text == string.Empty))
                    {
                        MessageBox.Show("Warning: Required empty field!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    MemoryStream mstream = new MemoryStream();
                    image1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] selectImage = mstream.ToArray();

                    connect.Open();
                    command = new SqlCommand("update tblItem set itemImage = @itemImage, itemName = @itemName, itemStatus = @itemStatus where itemID = @itemID", connect);
                    command.Parameters.AddWithValue("@itemImage", selectImage);
                    command.Parameters.AddWithValue("@itemName", txtName.Text);
                    command.Parameters.AddWithValue("@itemStatus", cmbStatus.SelectedItem);

                    
                    if (int.TryParse(txtID.Text, out itemId))
                    {
                        command.Parameters.AddWithValue("@itemId", itemId);
                    }
                    else
                    {
                        // handle the error
                    }
                    command.ExecuteNonQuery();
                    connect.Close();
                    this.Dispose();
                    MessageBox.Show("Edit successfully");
                    frm.viewItemList();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnItemImage_Click(object sender, EventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /*
                   

                     connect.Open();
                     command = new SqlCommand("insert into tblItem(itemImage, itemName, itemStatus)VALUEs(@itemImage, @itemName, @itemStatus)", connect);

                     command.Parameters.AddWithValue("@itemImage", selectImage);
                     command.Parameters.AddWithValue("@itemName", txtName.Text);
                     command.Parameters.AddWithValue("@itemStatus", cmbStatus.SelectedItem);
                     command.ExecuteNonQuery();
                     connect.Close();

                     MessageBox.Show("Successfully added!!!");
                     Clear();


         */
    }
}
