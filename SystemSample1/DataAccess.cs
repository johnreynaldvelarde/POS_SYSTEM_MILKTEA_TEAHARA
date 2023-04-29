using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace SystemSample1
{
  
    class DataAccess
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        

        public DataAccess() {

            connect = new SqlConnection(database.MyConnection());
           
        }

       
        public bool RecordSale(string sale_Person, DateTime sale_Date, decimal cash_given, decimal total_amount, decimal cash_return)
        {

            using (SqlConnection connect = new SqlConnection(database.MyConnection())) {

                   connect.Open();
                   SqlTransaction sqlTran = connect.BeginTransaction();
                   SqlCommand command = connect.CreateCommand();
                   command.Transaction = sqlTran;

                try {

                    command.Parameters.AddWithValue("@salesPerson", sale_Person);
                    command.Parameters.AddWithValue("@saleTime", sale_Date);
                    command.Parameters.AddWithValue("@cashGiven", cash_given);
                    command.Parameters.AddWithValue("@totalAmount", total_amount);
                    command.Parameters.AddWithValue("@cashReturn", cash_return);
                    command.CommandText = "insert into tblSales(salesPerson, saleTime, cashGiven, totalAmount, cashReturn )VALUEs(@salesPerson, @saleTime, @cashGiven, @totalAmount, @cashReturn)";
                    command.ExecuteNonQuery();
               
                    sqlTran.Commit();
                    connect.Close();

                    return true;   
                }
                catch 
                {
                    connect.Close();
                    return false;
                }
               
            }
           
        }

        // select sales product and retreive it
        public ArrayList RetreiveSaleItems(int SaleID)
        {
            ArrayList ProductsList = new ArrayList();

            using (SqlConnection connect = new SqlConnection(database.MyConnection()))
            {
                SqlCommand command = new SqlCommand(@"SELECT name, quantity, price, total FROM tblSales_Product where shareID = '" + SaleID + "';", connect);
                connect.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string ProductName = reader.GetString(0);
                        int ProductQuantity = reader.GetInt32(1);
                        decimal ProductPrice = reader.GetDecimal(2);
                        decimal ProductTotal = reader.GetDecimal(3);

                        ProductsList.Add(new Details() { Name = ProductName, Quantity = ProductQuantity, Price = ProductPrice, Total = ProductTotal });
                    }
                }
                reader.Close();

                return ProductsList;
            }
        }

    }
}
