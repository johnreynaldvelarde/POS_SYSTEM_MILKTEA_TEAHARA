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
    public partial class UserForm : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;

        private PictureBox pic;

        private Form activeForm = null;

        public UserForm()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            ShowUser();
        }

        private void openUser(Form childForm)
        {
            if (activeForm != null)

            activeForm.Close();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlfillUser.Controls.Add(childForm);
            pnlfillUser.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void btnCreateNewUser_Click(object sender, EventArgs e)
        {
            openUser(new CreateUserForm());
            
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            pnlfillUser.Controls.Add(flowUser);
            flowUser.BringToFront();
            flowUser.Show();

        }


        public void ShowUser()
        {
            flowUser.Controls.Clear();
            connect.Open();
            command = new SqlCommand("select image, username, role from tblUserAccount ", connect);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                long len = reader.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                reader.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                pic = new PictureBox();

                MemoryStream mstream = new MemoryStream(array);
                Bitmap bitmap = new Bitmap(mstream);
                pic.BackgroundImage = bitmap;


                Image pro = pic.BackgroundImage = bitmap;

                string uname = reader["username"].ToString();

                string role = reader["role"].ToString();

                UserControlUserView obj = new UserControlUserView(pro, uname, role);
                flowUser.Controls.Add(obj);

            }
            reader.Close();
            connect.Close();

        }
    }
}
