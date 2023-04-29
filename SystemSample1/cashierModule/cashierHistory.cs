using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemSample1.cashierModule
{
    public partial class cashierHistory : Form
    {
        private Form activeForm = null;

        public cashierHistory()
        {
            InitializeComponent();
            viewHistory();
        }


        private void openHistory(Form childForm)
        {
            if (activeForm != null)

                activeForm.Close();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelHistory.Controls.Add(childForm);
            panelHistory.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void viewHistory()
        {
            openHistory(new cashierHistory1());
        }

        private void btnHistoryOrder_Click(object sender, EventArgs e)
        {
            openHistory(new cashierHistory1());
        }
    }
}
