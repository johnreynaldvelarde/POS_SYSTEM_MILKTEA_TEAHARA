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
    public partial class LoginForm : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;

        List<ActivityLogEntry> logEntries = new List<ActivityLogEntry>();

        public LoginForm()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
        }

        private void Clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            string _username = "";
            string _role = "";
            string _password = "";
            Image _profile;

            try
            {
                bool found = false;

                connect.Open();
                command = new SqlCommand("select * from tblUserAccount where username = @username and password = @password", connect);
                command.Parameters.AddWithValue("@username", txtUsername.Text);
                command.Parameters.AddWithValue("@password", txtPassword.Text);
              
                
                reader = command.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {


                    found = true;
                    _username = reader["username"].ToString();
                    _password = reader["password"].ToString();
                    _role = reader["role"].ToString();
                    

                   
                    byte[] img = ((byte[])reader["image"]);
                    byte[] imagebytearray = img;

                    // MemoryStream stream = new MemoryStream(img);
                    _profile = Image.FromStream(new MemoryStream(img));
                  


                }
                else
                {
                    found = false;
                }
               // --------

                if (found == true)
                {
                    if (_role == "Administrator")
                    {
                        

                        MessageBox.Show( _username , "Access granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsername.Clear();
                        txtPassword.Clear();
                        this.Hide();
                        MainForm frm = new MainForm(this);
                        frm.labelUsername.Text = _username;
                        frm.labelRole.Text = _role;
                        MainClass.uname = _username;
                        
                        
                        byte[] img = ((byte[])reader["image"]);
                        byte[] imagebytearray = img;
                       
                        frm.pictureProfile.Image = _profile = Image.FromStream(new MemoryStream(img));

                        frm.ShowDialog();

                        logEntries.Add(new ActivityLogEntry(_username, "Logged in"));
                       
                        reader.Close();
                        connect.Close();

                        SaveToDatabase();


                    }
                    else 
                    {
                        MessageBox.Show(_username, "Access granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsername.Clear();
                        txtPassword.Clear();
                        this.Hide();
                        cashierModule.cashierMain cash = new cashierModule.cashierMain(this);
                        cash.labelUsername.Text = _username;
                        cash.labelRole.Text = _role;
                        MainClass.uname = _username;

                        byte[] img = ((byte[])reader["image"]);
                        byte[] imagebytearray = img;

                        cash.pictureProfile2.Image = _profile = Image.FromStream(new MemoryStream(img));
                        
                        cash.ShowDialog();

                        logEntries.Add(new ActivityLogEntry(_username, "Logged in"));
                     
                        reader.Close();
                        connect.Close();

                        SaveToDatabase();

                    }

                }
                else
                {
                    MessageBox.Show("Invalid username or password ", "Access Denied" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Clear();
                }

                reader.Close();
                connect.Close();

            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


           

        }

        public void SaveToDatabase()
        {
            using (var connection = new SqlConnection(database.MyConnection()))
            {
                connection.Open();
                foreach (var entry in logEntries)
                {
                    var query = "INSERT INTO tblActivityLog(user_name, action, timestamp) VALUES (@user_name, @action, @timestamp)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@user_name", entry.UserName);
                        command.Parameters.AddWithValue("@action", entry.Action);
                        command.Parameters.AddWithValue("@timestamp", entry.Timestamp);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void ShowHidePass_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowHidePass.Checked) 
            { 
                txtPassword.UseSystemPasswordChar = true;
            } else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }
    }
}
