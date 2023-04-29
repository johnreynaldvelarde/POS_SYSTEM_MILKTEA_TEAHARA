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
    public partial class viewSalesProduct : Form
    {
        int SaleID = 0;
        public viewSalesProduct(int  SaleID)
        {
            InitializeComponent();
            this.SaleID = SaleID;
        }


        // exit
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void viewSalesProduct_Load(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            int i = 0;
            foreach (Details SalesProduct in dataAccess.RetreiveSaleItems(SaleID))
            {
                i += 1;
                datagridSalesProduct.Rows.Add(i, SalesProduct.Name, SalesProduct.Quantity, SalesProduct.Price, SalesProduct.Total);
            }
        }
    }
}
