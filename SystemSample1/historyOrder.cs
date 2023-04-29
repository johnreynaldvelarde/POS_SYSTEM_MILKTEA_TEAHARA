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
    public partial class historyOrder : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;

        public historyOrder()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            viewOrderHistory();
        }

        public void viewOrderHistory()
        {
            int i = 0;

            datagridOrder.Rows.Clear();
            connect.Open();
            command = new SqlCommand("Select * from tblSales ", connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {


                i += 1;
                datagridOrder.Rows.Add(i, reader["ID"].ToString(), reader["salesPerson"], reader["saleTime"].ToString(), reader["totalAmount"].ToString());


            }
            reader.Close();
            connect.Close();
        }

        
        private void datagridOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                if (datagridOrder.Columns[e.ColumnIndex].Name == "Show")
                {
                    int SaleID = Convert.ToInt32(datagridOrder.Rows[e.RowIndex].Cells["orderID"].Value);

                    viewSalesProduct sales = new viewSalesProduct(SaleID);

                    sales.ShowDialog();
                }

                else if (datagridOrder.Columns[e.ColumnIndex].Name == "Delete")
                {
                    if (MessageBox.Show("Do you want to delete this transaction ?", "Delete the record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        connect.Open();
                        command = new SqlCommand("delete from tblSales where ID like '" + datagridOrder[1, e.RowIndex].Value.ToString() + "'", connect);
                        command.ExecuteNonQuery();
                        connect.Close();
                        MessageBox.Show("The selected transaction have been successfully deleted.", "Tea Hara", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        viewOrderHistory();

                    }


                }

            }
        }
    }
}
