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
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace SystemSample1.cashierModule
{
    public partial class cashierRoot1 : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        
        public cashierRoot1()
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


            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return total;
        }


        public void MonitorSales()
        {
            lblDaily.Text = GetTotal("SELECT SUM(totalAmount) AS total_sum FROM tblSales WHERE DATEPART(day, saleTime) = DATEPART(day, GETDATE()) AND DATEPART(month, saleTime) = DATEPART(month, GETDATE()) AND DATEPART(year, saleTime) = DATEPART(year, GETDATE())").ToString("#,##0.00");
            lblWeek.Text = GetTotal("SELECT SUM(totalAmount) AS total_sum FROM tblSales WHERE DATEPART(week, saleTime) = DATEPART(week, GETDATE()) AND DATEPART(year, saleTime) = DATEPART(year, GETDATE())").ToString("#,##0.00");
            lblMonth.Text = GetTotal("SELECT SUM(totalAmount) AS total_sum FROM tblSales WHERE DATEPART(month, saleTime) = DATEPART(month, GETDATE()) AND DATEPART(year, saleTime) = DATEPART(year, GETDATE())").ToString("#,##0.00");
            lblAnnual.Text = GetTotal("SELECT SUM(totalAmount) AS total_sum FROM tblSales WHERE DATEPART(year, saleTime) = DATEPART(year, GETDATE())").ToString("#,##0.00");

        }


        // chart about most sales by month
        public void salesMonth()
        {
            try
            {

                string query = "SELECT MONTH(saletime) as month, YEAR(saletime) as year, SUM(totalAmount) as totalAmount " +
                      "FROM tblSales " +
                      "GROUP BY MONTH(saletime), YEAR(saletime)";

                using (SqlConnection connection = new SqlConnection(database.MyConnection()))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        int month = reader.GetInt32(0);
                        int year = reader.GetInt32(1);
                        decimal totalAmount = reader.GetDecimal(2);
                        string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month);

                        chartSales.Series["Monthly Sales"].Points.AddXY(monthName + "/" + year, totalAmount);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void mostProduct()
        {
            try
            {

                string query = "SELECT name, SUM(quantity) as totalQuantity " +
                           "FROM tblSales_Product " +
                           "GROUP BY name " +
                           "ORDER BY totalQuantity DESC";


                using (SqlConnection connection = new SqlConnection(database.MyConnection()))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    int i = 0;

                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        int totalQuantity = reader.GetInt32(1);

                        chartMost.Series["MostHigh"].Points.AddXY(name, totalQuantity);
                        // chartMost.Series["MostHigh"].Points[i].Label = totalQuantity.ToString();
                        chartMost.Series["MostHigh"].Points[i].LabelForeColor = Color.White;
                        chartMost.Series["MostHigh"].Points[i]["Exploded"] = "True";
                        chartMost.Series["MostHigh"].Points[i].CustomProperties = "PieLabelStyle=Outside";

                        i++;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dashBoardPart1_Load(object sender, EventArgs e)
        {
            salesMonth();
            mostProduct();
        }


    }
}
