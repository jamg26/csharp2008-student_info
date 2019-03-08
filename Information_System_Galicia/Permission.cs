using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Information_System_Galicia
{
    class Permission
    {
        SqlConnection conn = dbClass.getConnection();

        public void UpdatePermission(string perm) {
            // after logged in this method will be called to update permission in the database
            SqlDataAdapter sd = new SqlDataAdapter();
            sd.UpdateCommand = new SqlCommand("UPDATE session SET type='" + perm + "' WHERE username='admin'", conn);
            conn.Open();
            sd.UpdateCommand.ExecuteNonQuery();
            conn.Close();
        }
        public string GetPermission()
        {
            // every form this method will be called to check users permission
            SqlCommand cmd = new SqlCommand("SELECT type FROM session WHERE username='admin'", conn);
            string perm = "";
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                perm = dr.GetString(0);
            }
            conn.Close();
            return perm;
        }
    }
}
