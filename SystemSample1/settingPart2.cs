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
    public partial class settingPart2 : Form
    {
        public settingPart2()
        {
            InitializeComponent();
        }

        private void btnRestor_Click(object sender, EventArgs e)
        {
            Restore restore = new Restore();
            restore.ShowDialog();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            BackUp backUp = new BackUp();
            backUp.ShowDialog();
        }
    }
}
