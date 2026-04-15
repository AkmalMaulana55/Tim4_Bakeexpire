using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tim4_Bakeexpire
{
    class Koneksi
    {
        return new SqlConnection("Data Source=.;Initial Catalog=db_bahan_kue;Integrated Security=True");
    }
}
