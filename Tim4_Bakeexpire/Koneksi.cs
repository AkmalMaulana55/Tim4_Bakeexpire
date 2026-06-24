using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Tim4_Bakeexpire
{
    class Koneksi
    {
        public static SqlConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["DbBakeExpire"].ConnectionString;
            return new SqlConnection(connStr);
        }
    }
}
