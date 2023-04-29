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
using System.IO;

namespace SystemSample1
{
    public partial class inventoryItem : Form
    {

        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();
        SqlDataReader reader;

        string item_id, item_name, item_status, item_qyt;
        Image item_image;
                        
        public inventoryItem()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
            viewItemList();
        }

        public void viewItemList()
        {
            int i = 0;
           
            datagridItem.Rows.Clear();
            connect.Open();
            command = new SqlCommand("Select * from tblItem ", connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {


                i += 1;
                datagridItem.Rows.Add(i, reader["itemID"].ToString(), reader["itemImage"], reader["itemName"].ToString(), reader["itemQyt"].ToString(), reader["itemStatus"].ToString());

      
            }
            reader.Close();
            connect.Close();
        }


        private void btnaddItem_Click(object sender, EventArgs e)
        {
            item_add add = new item_add();
            add.ShowDialog();

        }


        private void txtItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void datagridItem_SelectionChanged(object sender, EventArgs e)
        {
             

            int i = datagridItem.CurrentRow.Index;
            byte[] img = (byte[])datagridItem.Rows[i].Cells["itemImage"].Value; 
            
            item_image = Image.FromStream(new MemoryStream(img));
            item_name = datagridItem[3, i].Value.ToString();
            item_qyt = datagridItem[4, i].Value.ToString();
            item_status = datagridItem[5, i].Value.ToString();
            item_id = datagridItem[1, i].Value.ToString();
        }

        private void datagridItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnItem = datagridItem.Columns[e.ColumnIndex].Name;
            if (columnItem == "Edit")
            {
                if (MessageBox.Show("Do you want to edit this item?", "Edit the details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ItemAdd item = new ItemAdd(this);

                    item.txtName.Text = item_name;
                    item.image1.Image = item_image;
                    item.cmbStatus.Text = item_status;
                    item.txtID.Text = item_id;
                    item.ShowDialog();

                }

            }
            else if (columnItem == "Restock")
            {
                if (MessageBox.Show("Do you want to restock this item?", "Restock the item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ReStock stock = new ReStock(this);
                    stock.PassId = int.Parse(item_id);
                    stock.ShowDialog();

                }
            }
        }

        /*
        
                if (MessageBox.Show("Do you want to delete this item?", "Delete the record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connect.Open();
                    command = new SqlCommand("delete from tblItem where itemID like '" + datagridItem[1, e.RowIndex].Value.ToString() + "'", connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("The selected item have been successfully deleted.", "Tea Hara", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    viewItemList();

                }

        */
    }
}
