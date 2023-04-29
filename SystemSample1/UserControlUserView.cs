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
    public partial class UserControlUserView : UserControl
    {
        public UserControlUserView(Image pro, string uname, string role)
        {
            InitializeComponent();
            Profile = pro;
            UserName = uname;
            Role = role;


        }


        public Image Profile
        {

            get => ptrProfile.Image;
            set => ptrProfile.Image = value;
        }
        public string UserName
        {


            get => lblUserName.Text;
            set => lblUserName.Text = value + "";
        }
        public string Role
        {
            get => lblRole.Text;
            set => lblRole.Text = value + "";
        }
    }
}
