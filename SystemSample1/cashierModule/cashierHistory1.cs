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

namespace SystemSample1.cashierModule
{
    public partial class cashierHistory1 : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;

        public cashierHistory1()
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
                    sales.panel1.BackColor = Color.FromArgb(40, 185, 74);

                    sales.ShowDialog();
                }

              

            }
        }
    }
}
