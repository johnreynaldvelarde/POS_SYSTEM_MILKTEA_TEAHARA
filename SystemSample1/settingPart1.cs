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
    public partial class settingPart1 : Form
    {
        public settingPart1()
        {
            InitializeComponent();
        }

        private void settingPart1_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("timedate.cpl");
        }
    }
}
