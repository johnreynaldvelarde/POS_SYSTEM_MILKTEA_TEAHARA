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
    public partial class cashierDash1 : Form
    {
        private Form activeForm = null;

        public cashierDash1()
        {
            InitializeComponent();
            viewDash();
        }
        private void openHome(Form childForm)
        {
            if (activeForm != null)

                activeForm.Close();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelPut.Controls.Add(childForm);
            panelPut.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void viewDash()
        {

            openHome(new dashBoardPart1());
        }

    }
}
