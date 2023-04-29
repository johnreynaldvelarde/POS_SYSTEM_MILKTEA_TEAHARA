using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Data.SqlClient;

namespace SystemSample1.cashierModule
{
    public partial class cashierMenu : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;

        List<notification_log> notienter = new List<notification_log>();
        List<ActivityLogEntry> logEntries = new List<ActivityLogEntry>();
       
        public cashierMenu()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            flowPanel.Controls.Clear();
            LoadProducts();
            DataAccess da_ta = new DataAccess();
        }

        private void addItems(string id, string name, string price, Image pimage)
        {

            var w = new ucCashierProduct()
            {
                pImage = pimage,
                pName = name,
                pPrice = price,
                id = Convert.ToInt32(id),
            };

            flowPanel.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucCashierProduct)ss;

                foreach (DataGridViewRow item in dataGridOrder.Rows)
                {
                    if (Convert.ToInt32(item.Cells["gridID"].Value) == wdg.id)
                    {
                        // this check product alreadt there the one quantity and update price
                        item.Cells["gridQyt"].Value = int.Parse(item.Cells["gridQyt"].Value.ToString()) + 1;
                        item.Cells["gridAmount"].Value = int.Parse(item.Cells["gridQyt"].Value.ToString()) * double.Parse(item.Cells["gridPrice"].Value.ToString());
                        getTotal();
                        return;
                    }

                }
                // this line add new product
                dataGridOrder.Rows.Add(new object[] { 0, wdg.id, wdg.pName, 1, wdg.pPrice, wdg.pPrice });
                getTotal();
            };

        }

        private void LoadProducts()
        {
            flowPanel.Controls.Clear();
            connect.Open();
            command = new SqlCommand("select Image, Name, Price, productID, Deleted from tblProduct WHERE Deleted = 0", connect);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            foreach (DataRow item in data.Rows)
            {
                if (item["Deleted"].ToString() == "0")
                {
                    Byte[] imagearray = (byte[])item["Image"];
                    byte[] imagebytearray = imagearray;

                    addItems(item["productID"].ToString(), item["Name"].ToString(), item["Price"].ToString(), Image.FromStream(new MemoryStream(imagearray)));
                }
            }

            connect.Close();
        }


        // method clear
        public void Clear()
        {
            dataGridOrder.Rows.Clear();
            dataGridOrder.Refresh();
            lbltotalprice.Text = "0.00";

        }

        public void selectedProduct()
        {

            int saleID = ReturnSaleID();

            using (SqlConnection connect = new SqlConnection(database.MyConnection()))
            {

                try
                {


                    for (int i = 0; i < dataGridOrder.Rows.Count; i++)
                    {

                        command = new SqlCommand(@"INSERT INTO tblSales_Product(name, quantity, price, total, shareID)VALUES('" + dataGridOrder.Rows[i].Cells["gridName"].Value + "','" + dataGridOrder.Rows[i].Cells["gridQyt"].Value + "','" + dataGridOrder.Rows[i].Cells["gridPrice"].Value + "','" + dataGridOrder.Rows[i].Cells["gridAmount"].Value + "','" + saleID + "')", connect);
                        connect.Open();
                        command.ExecuteNonQuery();
                        connect.Close();

                    }

                    MessageBox.Show("Sucessfully added");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
        }
        public void countQuantity()
        {
            int totalQuantity = 0;


            foreach (DataGridViewRow row in dataGridOrder.Rows)
            {
                totalQuantity += Convert.ToInt32(row.Cells["gridQyt"].Value);
            }

            string query = "UPDATE tblItem SET itemQyt = itemQyt - @totalQuantity";
            using (SqlConnection connection = new SqlConnection(database.MyConnection()))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@totalQuantity", totalQuantity);
                    command.ExecuteNonQuery();
                }

                connection.Close();

            }

        }

        public int ReturnSaleID()
        {
            int saleID = 1;
            try
            {
                using (SqlConnection connect = new SqlConnection(database.MyConnection()))
                {

                    connect.Open();
                    command = new SqlCommand("Select MAX(ID) FROM tblSales ", connect);
                    reader = command.ExecuteReader();
                    //SqlCommand command = new SqlCommand("SELECT MAX(ID) FROM Sales;", connection);

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            saleID = reader.GetInt32(0);
                        }
                    }
                    reader.Close();

                    saleID = saleID + 0;

                    return saleID;

                }

            }
            catch (Exception)
            {
                return saleID;
            }
        }

        // method to compute all price
        public void getTotal()
        {
            double total = 0;
            lbltotalprice.Text = "";
            foreach (DataGridViewRow item in dataGridOrder.Rows)
            {

                total += double.Parse(item.Cells["gridAmount"].Value.ToString());

            }

            lbltotalprice.Text = total.ToString("N2");

        }

        private void btnPay_Click_1(object sender, EventArgs e)
        {

            if (dataGridOrder.Rows.Count == 0)
            {
                MessageBox.Show("No order Try again!!!");
            }
            else
            {

                cashierPayment payment = new cashierPayment();

                payment.txtAmount.Text = lbltotalprice.Text;

                if (payment.ShowDialog() == DialogResult.OK)
                {

                    DataAccess da_ta = new DataAccess();

                    if (da_ta.RecordSale(payment.labelPerson.Text, payment.dateTimePicker1.Value, Convert.ToDecimal(payment.txtCashGiven.Text), Convert.ToDecimal(payment.txtAmount.Text), Convert.ToDecimal(payment.textCashReturn.Text)))
                    {

                        MessageBox.Show("New order added");
                        selectedProduct();
                        countQuantity();
                        Clear();

                        menuPayment menu = new menuPayment();
                        menu.print();
                        logEntries.Add(new ActivityLogEntry(MainClass.uname, " Created a new order using product in the cart "));
                        logEntries.Add(new ActivityLogEntry(MainClass.uname, " Submitted the order to complete the transaction."));

                        SaveToDatabase();
                        CheckItemQuantity();
                    }
                    else MessageBox.Show("No new order added");
                }
            }
        }

        private void CheckItemQuantity()
        {

            using (SqlConnection connection = new SqlConnection(database.MyConnection()))
            {


                connection.Open();
                SqlCommand command = new SqlCommand("SELECT itemName, itemQyt, itemImage FROM tblItem", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string item_name = reader.GetString(0);
                    int itemQyt = reader.GetInt32(1);

                    long bytesize = reader.GetBytes(2, 0, null, 0, 0);
                    byte[] imageData = new byte[bytesize];
                    reader.GetBytes(2, 0, imageData, 0, (int)bytesize);

                    if (itemQyt < 100)
                    {
                        string message = "The stock quantity of " + item_name + " is below threshold!";

                        AlertForm alert = new AlertForm();
                        alert.BackColor = Color.FromArgb(7, 124, 214);
                        alert.lblName.Text = message;
                        using (var ms = new MemoryStream(imageData))
                        {
                            alert.alertImage.Image = Image.FromStream(ms);
                        }

                        alert.Show();

                        bool isShown = false;

                        if (!isShown)
                        {
                            isShown = true;

                            Timer timer = new Timer();
                            timer.Interval = 5 * 1000;
                            timer.Tick += new EventHandler((s, args) => alert.Close());
                            timer.Start();
                        }

                        notienter.Add(new notification_log(item_name, message, imageData));
                        // return true;
                    }
                }

                saveNoti();
            }
            // return false;
        }


        private void btnClear_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtFilter_TextChanged_1(object sender, EventArgs e)
        {
            foreach (var item in flowPanel.Controls)
            {
                var product = (ucCashierProduct)item;
                product.Visible = product.pName.ToLower().Contains(txtFilter.Text.Trim().ToLower());

            }
        }

        private void dataGridOrder_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;

            foreach (DataGridViewRow row in dataGridOrder.Rows)
            {
                count++;
                row.Cells[0].Value = count;

            }
        }

        public void saveNoti()
        {
            using (var connection = new SqlConnection(database.MyConnection()))
            {
                connection.Open();
                foreach (var en in notienter)
                {
                    var query = "INSERT INTO tblNotification(noti_name, noti_action, noti_time, noti_image) VALUES(@noti_name, @noti_action, @noti_time, @noti_image)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@noti_name", en.itemName);
                        command.Parameters.AddWithValue("@noti_action", en.noTi);
                        command.Parameters.AddWithValue("@noti_time", en.Timestamp);
                        using (var ms = new MemoryStream())
                        {
                            en.itemImage.Save(ms, en.itemImage.RawFormat);
                            command.Parameters.AddWithValue("@noti_image", ms.ToArray());
                        }
                        command.ExecuteNonQuery();

                    }
                }
            }
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

    }
}
