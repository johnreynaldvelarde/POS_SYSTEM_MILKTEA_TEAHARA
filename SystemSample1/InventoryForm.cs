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
    public partial class InventoryForm : Form
    {


        private Form activeForm = null;

        public InventoryForm()
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

        public void viewProduct()
        {
            openInventory(new inventoryProduct());
        }

        private void btnproductVIew_Click(object sender, EventArgs e)
        {
            openInventory(new inventoryProduct());
        }

        private void btnitemView_Click(object sender, EventArgs e)
        {
            openInventory(new inventoryItem());
        }

        private void btnViewCategory_Click(object sender, EventArgs e)
        {
            openInventory(new inventoryCategory());
        }
    }
}
