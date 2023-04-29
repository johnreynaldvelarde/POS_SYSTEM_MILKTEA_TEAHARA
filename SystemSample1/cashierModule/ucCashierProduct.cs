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
    public partial class ucCashierProduct : UserControl
    {
        public ucCashierProduct()
        {
            InitializeComponent();
        }
        public event EventHandler onSelect = null;

        public int id { get; set; }
        public string price { get; set; }

        public Image pImage
        {
            get { return productImage.Image; }
            set { productImage.Image = value; }
        }


        public string pName
        {
            get { return lblname.Text; }
            set { lblname.Text = value; }
        }

        public string pPrice
        {
            get { return lblprice.Text; }
            set { lblprice.Text = value; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}
