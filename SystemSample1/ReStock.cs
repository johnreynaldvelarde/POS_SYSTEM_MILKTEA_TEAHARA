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

namespace SystemSample1
{
    public partial class ReStock : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        inventoryItem aa;
       
        public ReStock(inventoryItem bb)
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            aa = bb;
        }

        public int PassId { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtStock.Clear();
            txtStock.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connect.Open();
            command = new SqlCommand("UPDATE tblItem SET itemQyt = itemQyt + @itemQyt WHERE itemID = @itemID", connect);

            command.Parameters.AddWithValue("@itemQyt", Convert.ToInt32(txtStock.Text));
            command.Parameters.AddWithValue("@itemID", PassId);

            command.ExecuteNonQuery();
            connect.Close();
            this.Dispose();
            MessageBox.Show("Restock successfully");
            aa.viewItemList();

        }
    }
}
