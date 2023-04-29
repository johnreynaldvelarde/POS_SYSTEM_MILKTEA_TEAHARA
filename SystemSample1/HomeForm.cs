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

    public partial class HomeForm : Form
    {
        private Form activeForm = null;

        public HomeForm()
        {
            InitializeComponent();
            viewHome();
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
        public void viewHome()
        {
           
            openHome(new dashBoardPart1());
        }
        private void btnAboutProduct_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {

        }

        private void btnRight_Click(object sender, EventArgs e)
        {

        }
    }
}
