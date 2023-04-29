using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSample1
{
    class RecycleCode
    {
        // +++ MENU FORM +++
        //SqlDataReader reader;
        //private PictureBox pic;
        //private string tag;
        //double total;

        // SHOW THE ALL PRODUCT IN MENU
        /*
        public void ShowProduct()
        {
           // Select Image, Name, Price from tblProduct "
            flowPanel.Controls.Clear();
            connect.Open();
            command = new SqlCommand("select Image, Name, Price, productID from tblProduct ", connect);
            reader = command.ExecuteReader();

            // int x = 1, y = 1;

            while (reader.Read())
            {
                

                // int id = int.Parse(reader[0] + "");
                long len = reader.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                reader.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                pic = new PictureBox();

                MemoryStream mstream = new MemoryStream(array);
                Bitmap bitmap = new Bitmap(mstream);
                pic.BackgroundImage = bitmap;
                //double.Parse(reader[4] + "").ToString("col4");
                //Image.FromFile(@"Image" + reader[1]);
                
                
                
                Image im = pic.BackgroundImage = bitmap;
               
                string name = reader["Name"].ToString();
                
                string price =  reader["Price"].ToString();
                string id = reader["productID"].ToString();
               // pic.Tag = reader["productID"].ToString();
              
                UserControlItem obj = new UserControlItem(im, name, price, id);
                flowPanel.Controls.Add(obj);

                obj.btnAdd.Tag = reader["productID"].ToString();

              
                //flowOrder.Controls.Add(order);

            }
            reader.Close();
            connect.Close();
        }
        */


        // lbltotalprice.Text = total.ToString("#,##0.00");



        // method to show item in menu

        // dataGridView1.Columns.C
        /*
        int var_item = 0;
        int var_pay = 0;
        int result = 0;
        var_item = Convert.ToInt32(gridQyt);
        var_pay = Convert.ToInt32(gridAmount);

        result = var_item - var_pay;
        try
        {
            connect.Open();
            command = new SqlCommand("insert into tblOrder(itemImage, itemName, itemQyt, itemStatus)VALUEs(@itemImage, @itemName, @itemQyt, @itemStatus)", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        MessageBox.Show("Accept Order");
           /*
               // string query2 = "UPDATE tblItem SET itemQyt = itemQyt - @itemQyt WHERE ItemID = @ItemID";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@itemQyt", totalQuantity);
                    command.Parameters.AddWithValue("@ItemID", item2);

                    command.ExecuteNonQuery();
                }

              //  string query3 = "UPDATE tblItem SET itemQyt = itemQyt - @itemQyt WHERE ItemID = @ItemID";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@itemQyt", totalQuantity);
                    command.Parameters.AddWithValue("@ItemID", item3);

                    command.ExecuteNonQuery();
                }
                */

        



    }
}
