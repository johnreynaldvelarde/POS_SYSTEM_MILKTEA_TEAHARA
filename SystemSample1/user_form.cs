using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemSample1
{
    public partial class user_form : Form
    {
        private Form activeForm = null;

        public user_form()
        {
            InitializeComponent();
            viewUser();
        }


        private void openAccount(Form childForm)
        {
            if (activeForm != null)

                activeForm.Close();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelUser.Controls.Add(childForm);
            panelUser.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void viewUser()
        {
            openAccount(new user_list());
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            openAccount(new CreateUserForm());
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            openAccount(new user_list());
        }

        private void btnModule_Click(object sender, EventArgs e)
        {
            openAccount(new UserForm());
        }
    }
}
