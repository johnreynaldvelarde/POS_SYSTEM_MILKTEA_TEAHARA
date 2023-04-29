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

namespace SystemSample1
{
    public partial class menuPayment : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        List<ActivityLogEntry> logEntries = new List<ActivityLogEntry>();
        public menuPayment()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            
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

        // button clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            paymentClear();
        }

       
      
        // save the sale/product details in database then print the bill
        

        public void btnPrintBills_Click(object sender, EventArgs e)
        {
           
            if (txtCashGiven.Text == "")
            {
                MessageBox.Show("No cash input Try Again!!!");

            }
            
        }
     

        private void txtCashGiven_TextChanged(object sender, EventArgs e)
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

        private void txtCashGiven_KeyPress(object sender, KeyPressEventArgs e)
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

        private void menuPayment_Load(object sender, EventArgs e)
        {
            labelPerson.Text = MainClass.uname;
           // txtCashGiven.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void SaveToDatabase()
        {
            using (var connection = new SqlConnection(database.MyConnection()))
            {
                connection.Open();
                foreach (var entry in logEntries)
                {
                    var query = "INSERT INTO tblActivityLog(user_name, action, timestamp) VALUES (@user_name, @action, @timestamp)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@user_name", entry.UserName);
                        command.Parameters.AddWithValue("@action", entry.Action);
                        command.Parameters.AddWithValue("@timestamp", entry.Timestamp);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Tea hara", new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(10, 10));
        }

        public void print()
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
