using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace SystemSample1.cashierModule
{
    public partial class cashierPayment : Form
    {
        public cashierPayment()
        {
            InitializeComponent();
        }

        // button exit
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // method clear
        public void paymentClear()
        {
            txtCashGiven.Clear();
            txtCashGiven.Focus();
        }

      
        // save the sale/product details in database then print the bill


        public void btnPrintBills_Click(object sender, EventArgs e)
        {

            if (txtCashGiven.Text == "")
            {
                MessageBox.Show("No cash input Try Again!!!");

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cashierPayment_Load_1(object sender, EventArgs e)
        {
            labelPerson.Text = MainClass.uname;
        }

        private void txtCashGiven_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                textCashReturn.Text = (Convert.ToDecimal(txtCashGiven.Text) - Convert.ToDecimal(txtAmount.Text)).ToString();
            }
            catch
            {
                textCashReturn.Text = string.Empty;
            }
        }

        private void txtCashGiven_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {


            }
            else if (e.KeyChar == 8)
            {

            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57)) //ascii code 48-57 between 0-9
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            paymentClear();
        }

        private void btnPrintBills_Click_1(object sender, EventArgs e)
        {
            try
            {
                textCashReturn.Text = (Convert.ToDecimal(txtCashGiven.Text) - Convert.ToDecimal(txtAmount.Text)).ToString();
            }
            catch
            {
                textCashReturn.Text = string.Empty;
            }
        }
    }
}