using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemSample1
{
    public partial class AlertForm : Form
    {
        private static int numOfFormsOpened = 0;
        public AlertForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 15;
            int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height - 15;
            y -= (numOfFormsOpened * this.Height);
            int margin = -80; 
            y -= (numOfFormsOpened * (this.Height + margin));
            this.Location = new Point(x, y);
            this.TopMost = true;
            numOfFormsOpened++;
            this.FormClosed += DecrementNumOfFormsOpened;
        }

        void DecrementNumOfFormsOpened(object sender, FormClosedEventArgs e)
        {
            numOfFormsOpened--;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlertForm_Load(object sender, EventArgs e)
        {

        }
    }
}
