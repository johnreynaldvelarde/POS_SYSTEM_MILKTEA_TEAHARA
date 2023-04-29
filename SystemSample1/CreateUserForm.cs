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
using System.Text.RegularExpressions;

namespace SystemSample1
{
    public partial class CreateUserForm : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        

        public CreateUserForm()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());

        }

        // Clear Method
        public void Clear()
        {
            btnSave.Enabled = true;
            txtUsername.Clear();
            txtPassword.Clear();
            txtRetype.Clear();
            cmbRole.Text = "";
            txtUsername.Focus();
            Graphics g = profilePicture.CreateGraphics();
            g.Clear(Color.White);

        }
        
       
        // Button Add image
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                /*
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images(.jpg, .png)|*.png, *jpg ";
                if (ofd.ShowDialog()==DialogResult.OK)
                {
                    filepath = ofd.FileName;
                    profilePicture.Image = new Bitmap(filepath);
                }

                */
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image Files (*.png)|*.png|(*.jpg)|*.jpg|(*.gif)|*.gif";
                // openFileDialog1.Filter = "Image Files (*.png)|*.png|(*.jpg)|*.jpg|(*.gif)|*.gif";
                // openFileDialog1.ShowDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    profilePicture.BackgroundImage = Image.FromFile(ofd.FileName);
                }
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Button Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }


        // Button Save
        private void btnSave_Click(object sender, EventArgs e)
        {
           // string pattern = "^.*(?=.{8,})(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.[!@#$%^&+=]).*$";
            Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");

                
                 if (!regex.IsMatch(txtPassword.Text))
                {
                    MessageBox.Show("Password must have 8-20 characters long with at least one numeric character, uppercase, lowercase and special character", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                else
                {
                    MessageBox.Show("Good password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if(txtUsername.Text == "" || txtPassword.Text == "" || txtRetype.Text == "" || cmbRole.Text == "")
                         {
                             MessageBox.Show("Missing information Try Again!!!");
                    
                         }
                        else if(txtPassword.Text != txtRetype.Text)
                         {
                             MessageBox.Show("Password did not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                             return;

                         }
                        else
                         {
                            try
                             {
                                 MemoryStream mstream = new MemoryStream();
                                 profilePicture.BackgroundImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                                 byte[] selectImage = mstream.GetBuffer();

                                connect.Open();
                                command = new SqlCommand("insert into tblUserAccount(username, password, role, image)VALUEs(@username, @password, @role, @image)", connect);


                                command.Parameters.AddWithValue("@username", txtUsername.Text);
                                command.Parameters.AddWithValue("@password", txtPassword.Text);
                                command.Parameters.AddWithValue("@role", cmbRole.SelectedItem);
                                command.Parameters.AddWithValue("@image", selectImage);
                                command.ExecuteNonQuery();

                                connect.Close();

                                MessageBox.Show("New user account added!!!");
                                Clear();

                             }
                            catch (Exception ex)
                             {
                                  MessageBox.Show(ex.Message);
                             }


                         }
                }
               

               /*
                    MemoryStream mstream = new MemoryStream();
                    profilePicture.BackgroundImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] selectImage = mstream.GetBuffer();

                    connect.Open();
                    command = new SqlCommand("insert into tblUserAccount(username, password, role, image)VALUEs(@username, @password, @role, @image)", connect);

                    
                    command.Parameters.AddWithValue("@username", txtUsername.Text);
                    command.Parameters.AddWithValue("@password", txtPassword.Text);
                    command.Parameters.AddWithValue("@role", cmbRole.SelectedItem);
                    command.Parameters.AddWithValue("@image", selectImage);
                    command.ExecuteNonQuery();

                    connect.Close();

                    MessageBox.Show("New user account added!!!");
                    Clear();
               */
            
                
          

        }

        // Button View Password
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void passhide1_CheckedChanged(object sender, EventArgs e)
        {
           
                if (passhide1.Checked)
                {
                    txtPassword.UseSystemPasswordChar = true;
                }
                else
                {
                    txtPassword.UseSystemPasswordChar = false;
                }
            
        }

        private void passhide2_CheckedChanged(object sender, EventArgs e)
        {
                if (passhide2.Checked)
                {
                    txtRetype.UseSystemPasswordChar = true;
                }
                else
                {
                    txtRetype.UseSystemPasswordChar = false;
                }

        }
    }
}
