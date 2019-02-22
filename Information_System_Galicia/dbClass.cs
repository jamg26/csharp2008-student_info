using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Information_System_Galicia
{
    class dbClass
    {
        public static SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source = sqlserverinstance.crxgtyhmldr1.ap-southeast-1.rds.amazonaws.com; Initial Catalog = Info_Sys_Galicia; User ID=jamg;Password=Jamuel26;");
            return conn;
        }
    }
}
