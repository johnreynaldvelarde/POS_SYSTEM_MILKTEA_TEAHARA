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
    public partial class BackUp : Form
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();

        public BackUp()
        {
            InitializeComponent();
            connect = new SqlConnection(database.MyConnection());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //this method is to backup database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to backup your database? ", "Backup the database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if ((txtDatabase.Text == string.Empty) || (txtServer.Text == string.Empty))
                {
                    MessageBox.Show("Warning: Required empty field!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime d = DateTime.Now;
                string dd = d.Day + " - " + d.Month;

                string servname = txtServer.Text;
                string dbname = txtDatabase.Text;

                string dbconn = @"Data Source=" + servname + ";Initial Catalog=" + dbname + ";Integrated Security=True";
                SqlConnection connect = new SqlConnection(dbconn);

                connect.Open();
                string str = "USE " + dbname + ";";
                string str1 = "BACKUP DATABASE " + dbname +
                          " TO DISK = 'C:\\BackupDB\\" + dbname + "_" + dd +
                          ".Bak' WITH FORMAT ,MEDIANAME = 'Z_SQLServerBackups', NAME = ' Full Backup of " + dbname + "';";
                SqlCommand cmd1 = new SqlCommand(str, connect);
                SqlCommand cmd2 = new SqlCommand(str1, connect);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Successfully Complete Backup. You can find this file " + dbname +".Bak in your Disk C:\\BackupDB.... never edit this file name.");
                connect.Close();

            }

        }

        // this method clear
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtServer.Clear();
            
            txtDatabase.Clear();

            txtServer.Focus();
        }
    }
}
