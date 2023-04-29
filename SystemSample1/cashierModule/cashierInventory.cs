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
    public partial class cashierInventory : Form
    {
        private Form activeForm = null;
        public cashierInventory()
        {
            InitializeComponent();
            viewProduct();
        }


        private void openInventory(Form childForm)
        {
            if (activeForm != null)

                activeForm.Close();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelInventory.Controls.Add(childForm);
            panelInventory.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnproductVIew_Click(object sender, EventArgs e)
        {
            openInventory(new cashierInventory1());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            openInventory(new cashierInveotry2());
        }


        public void viewProduct()
        {
            openInventory(new cashierInventory1());
        }
    }
}
