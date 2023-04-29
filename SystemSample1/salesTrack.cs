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
    public partial class salesTrack : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        public salesTrack()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            MonitorSales();
        }

        public double GetTotal(string sql)
        {
            double total = 0;
            try
            {
                connect.Open();

                command = new SqlCommand(sql, connect);
                total = double.Parse(command.ExecuteScalar().ToString());

                connect.Close();


            }catch(Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return total;
        }

        public void MonitorSales()
        {
            lblDaily.Text = GetTotal("SELECT SUM(totalAmount) AS total_sum, GETDATE() AS saleTime FROM tblSales").ToString("#,##0.00");
            lblWeek.Text = GetTotal("SELECT SUM(totalAmount) AS total_sum, saleTime(ISO_WEEK, GETDATE()) AS saleTime FROM tblSales").ToString("#,##0.00");
            lblMonth.Text = GetTotal("SELECT SUM(totalAmount) from tblSales where saleTime(MONTH, saleTime) = DATEPART(MONTH, getdate())").ToString("#,##0.00");
            lblAnnual.Text = GetTotal("SELECT SUM(totalAmount) from tblSales where saleTime(YEAR, saleTime) = DATEPART(YEAR, getdate())").ToString("#,##0.00");
           
        }

        private void salesTrack_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
