using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Information_System_Galicia {
    class dbClass {
        public string dbS = "sqlserverinstance.crxgtyhmldr1.ap-southeast-1.rds.amazonaws.com";
        public string dbN = "Info_Sys_Galicia";
        public string dbU = "jamg";
        public static SqlConnection getConnection() {
            string dbServer = "sqlserverinstance.crxgtyhmldr1.ap-southeast-1.rds.amazonaws.com";
            string dbName = "Info_Sys_Galicia";
            string dbUser = "jamg";
            SqlConnection conn = new SqlConnection("Data Source = " + dbServer + "; Initial Catalog = " + dbName + "; User ID=" + dbUser + ";Password=Jamuel26;");
            return conn;
        }
        public string getDbServer() {
            return dbS;
        }
    }
}