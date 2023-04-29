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
   
    public partial class SettingForm : Form
    {
        private Form activeForm = null;

        public SettingForm()
        {
            InitializeComponent();
            viewSetting();
        }

        private void openSettings(Form childForm)
        {
            if (activeForm != null)

                activeForm.Close();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelSettings.Controls.Add(childForm);
            panelSettings.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void viewSetting()
        {
            openSettings(new settingPart1());
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            openSettings(new settingPart2());
        }

        private void btnChangeTime_Click(object sender, EventArgs e)
        {
            openSettings(new settingPart1());
        }
    }
}
