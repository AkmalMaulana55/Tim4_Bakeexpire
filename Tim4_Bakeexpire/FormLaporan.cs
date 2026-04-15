using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tim4_Bakeexpire
{
    public partial class FormLaporan: Form
    {
        public FormLaporan()
        {
            InitializeComponent();
        }

        private void FormLaporan_Load(object sender, EventArgs e)
        {
            cmbFilter.Items.Add("Semua");
            cmbFilter.Items.Add("Hampir Kadaluwarsa");
            cmbFilter.Items.Add("Kadaluwarsa");
            cmbFilter.SelectedIndex = 0;

            TampilLaporan();
        }

        void TampilLaporan()
        {
            SqlConnection conn = Koneksi.GetConnection();
            conn.Open();

            string query = "SELECT Bahan.Nama_bahan, Stok.Status, Laporan.Tindakan, Laporan.Keterangan, Laporan.Tanggal_laporan " +
                           "FROM Laporan " +
                           "JOIN Stok ON Laporan.Id_stok = Stok.Id_stok " +
                           "JOIN Bahan ON Stok.Id_bahan = Bahan.Id_bahan";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewLaporan.DataSource = dt;
        }
    }
}
