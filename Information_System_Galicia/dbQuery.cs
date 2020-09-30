using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Information_System_Galicia
{
    class dbQuery
    {
        SqlConnection connect = dbClass.getConnection();

        public void dbInsert(string query) {
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.InsertCommand = new SqlCommand(query, connect);
            connect.Open();
            sda.InsertCommand.ExecuteNonQuery(); // inserting new course to the database
            connect.Close();
        }

        public void dbUpdate(string query) {
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.UpdateCommand = new SqlCommand(query, connect);
            connect.Open();
            sda.UpdateCommand.ExecuteNonQuery();
            connect.Close();
        }

        public void dbDelete(string query) {
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.UpdateCommand = new SqlCommand(query, connect);
            connect.Open();
            sda.UpdateCommand.ExecuteNonQuery();
            connect.Close();
        }
    }
}
