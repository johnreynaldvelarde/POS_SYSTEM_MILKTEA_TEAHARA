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
   
    public partial class MainForm  : Form 
    {
       
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        
        LoginForm lg;

        List<ActivityLogEntry> logEntries = new List<ActivityLogEntry>();

      
        private Form activeForm = null;
        bool sidebarExpand;


        public MainForm(LoginForm frm)
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            connect.Open();
            lg = frm;
            viewHome();
            // MessageBox.Show("Connected");

        


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

        public void viewHome()
        {
            openChildForm(new HomeForm());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            HomeForm home = new HomeForm();

            openChildForm(new HomeForm());

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnMenu.Height;
            SidePanel.Top = btnMenu.Top;
            openChildForm(new MenuForm());
          
       
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnInventory.Height;
            SidePanel.Top = btnInventory.Top;
            openChildForm(new InventoryForm());
            

        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnUser.Height;
            SidePanel.Top = btnUser.Top;
          
            openChildForm(new user_form());
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnHistory.Height;
            SidePanel.Top = btnHistory.Top;
            openChildForm(new HistoryForm());

            
        }
        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = btnSettings.Height;
            SidePanel.Top = btnSettings.Top;
            openChildForm(new SettingForm());
        }

       

        private void btnLogout_Click(object sender, EventArgs e)
        {
            

            DialogResult res;
            res = MessageBox.Show("Do you want to logout", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                this.Dispose();
                logEntries.Add(new ActivityLogEntry(MainClass.uname, "Logged out"));
                SaveToDatabase();
                LoginForm form = new LoginForm();
                form.Show();
            }
            else
            {
                this.Show();
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

        private  void btnupExit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to logout", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                this.Dispose();
                logEntries.Add(new ActivityLogEntry(MainClass.uname, "Logged out"));
                SaveToDatabase();
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
            else if(WindowState == FormWindowState.Maximized)
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


        // CODE FOR SLIDING BAR
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand)
            {
                // if the sidebar is expand
                sidebar.Width -= 10;
                
                if(sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if(sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }


        }

        private void btnSlide_Click_1(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void pictureProfile_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
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
            noti.ShowDialog();
        }
      
    }
}
