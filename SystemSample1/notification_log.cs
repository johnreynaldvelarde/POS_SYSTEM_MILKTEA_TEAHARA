using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace SystemSample1
{
    class notification_log
    {
        SqlConnection connect = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataBaseConnection database = new DataBaseConnection();

        List<notification_log> notienter = new List<notification_log>();

      //  Image ss { get; set };

        public string itemName { get; set; }
        public string noTi { get; set; }
        public DateTime Timestamp { get; set; }

        public Image itemImage { get; set; }


        public notification_log(string itemname, string noti, byte[] imageData)
        {
            itemName = itemname;
            noTi = noti;
            Timestamp = DateTime.Now;
            using (var ms = new MemoryStream(imageData))
            {
                itemImage = Image.FromStream(ms);
            }
        }

    }
}
