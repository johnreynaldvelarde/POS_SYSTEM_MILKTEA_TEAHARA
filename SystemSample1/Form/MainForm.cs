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
    public partial class MainForm : Form
    {
        private Button currentButton;
        private Form activeForm;

        bool sidebarExpand;

        private void OpenChildForm(Form childForm, object btnSender)
        {
            

        }


        public MainForm()
        {
            InitializeComponent();
           
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            
            HomeForm frm = new HomeForm();

            frm.TopLevel = false;
            panelALL.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();      
            
          
              
            


        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnMenu.Height;
            SidePanel.Top = btnMenu.Top;

            



        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnInventory.Height;
            SidePanel.Top = btnInventory.Top;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnHistory.Height;
            SidePanel.Top = btnHistory.Top;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnSettings.Height;
            SidePanel.Top = btnSettings.Top;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            

            DialogResult res;
            res = MessageBox.Show("Do you want to logout", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                Application.Exit();
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
                Application.Exit();
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

      
    }
}
