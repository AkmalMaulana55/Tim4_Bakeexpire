using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tim4_Bakeexpire
{
    class DataLaporan
    {
        public int Id_laporan { get; set; }
        public string Nama_bahan { get; set; }
        public string Petugas { get; set; }
        public string Tindakan { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tanggal_Laporan { get; set; }
    }
}
