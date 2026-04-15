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

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Koneksi.GetConnection();
            conn.Open();

            string query;

            if (cmbFilter.Text == "Semua")
                query = "SELECT * FROM Laporan";
            else
                query = "SELECT Laporan.*, Stok.Status FROM Laporan " +
                        "JOIN Stok ON Laporan.Id_stok = Stok.Id_stok " +
                        "WHERE Stok.Status=@status";

            SqlCommand cmd = new SqlCommand(query, conn);

            if (cmbFilter.Text != "Semua")
                cmd.Parameters.AddWithValue("@status", cmbFilter.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewLaporan.DataSource = dt;
        }
    }
}
