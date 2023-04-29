using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SystemSample1
{
    class DataBaseConnection  
    {
       
        public string MyConnection()
        {
            // @"Data Source=JERICHO-GARCIA;Initial Catalog=POSandInventory;Integrated Security=True" == DATABASE NI JERICHO
            // @"Data Source=LENOVO-PC;Initial Catalog=PosSystem;Integrated Security=True" -> Database ni velarde
            // @"Data Source=DESKTOP-VKHU5QN\SQLEXPRESS;Initial Catalog=PosandInventory;Integrated Security=True" -_- Database ni Ocnic
            string con = @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=PosSystem;Integrated Security=True"; 
            return con;
        }
    }



}
