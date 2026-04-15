using System;
using System.Data.SqlClient;

namespace Tim4_Bakeexpire
{
    class Koneksi
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=MYBOOKHYPE\\AKMALSQL;Initial Catalog=db_bakeexpire;Integrated Security=True");
        }
    }
}