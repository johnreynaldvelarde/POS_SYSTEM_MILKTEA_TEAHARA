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


namespace SystemSample1.cashierModule
{
    public partial class cashierMain : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        LoginForm lg;

        private Form activeForm = null;
        bool sidebarExpand;

        public cashierMain(LoginForm frm)
        {
            InitializeComponent();
            lg = frm;
            viewCashier();
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)

                activeForm.Close();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void viewCashier() {
            openChildForm(new cashierMenu());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnDashboard.Height;
            SidePanel.Top = btnDashboard.Top;

            openChildForm(new cashierDash1());

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnMenu.Height;
            SidePanel.Top = btnMenu.Top;

            openChildForm(new cashierMenu());

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {

            SidePanel.Height = btnInventory.Height;
            SidePanel.Top = btnInventory.Top;
            openChildForm(new cashierInventory());

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {

            SidePanel.Height = btnHistory.Height;
            SidePanel.Top = btnHistory.Top;

            openChildForm(new cashierHistory());
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to logout", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                this.Dispose();
                LoginForm form = new LoginForm();
                form.Show();
            }
            else
            {
                this.Show();
            }
        }


        private void btnupExit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to logout", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                this.Dispose();
                LoginForm form = new LoginForm();
                form.Show();

            }
            else
            {
                this.Show();

            }

        }

        private void btnupEnlarge_Click(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }

        }

        private void btnupMinimize_Click(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Minimized;
            }

        }

   
        private void btnSlide_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void sidebarTimer_Tick_1(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                // if the sidebar is expand
                sidebar.Width -= 10;

                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void cashierMain_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToLongDateString();
            lbltime.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            Notification noti = new Notification();
            noti.panel1.BackColor = Color.FromArgb(40, 185, 74);
            noti.ShowDialog();
        }
    }
}
