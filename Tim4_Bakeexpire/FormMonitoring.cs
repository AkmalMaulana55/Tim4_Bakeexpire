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
    public partial class FormMonitoring: Form
    {
        public FormMonitoring()
        {
            InitializeComponent();
        }

        private void FormMonitoring_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Add("Semua");
            cmbStatus.Items.Add("Aman");
            cmbStatus.Items.Add("Hampir Kadaluwarsa");
            cmbStatus.Items.Add("Kadaluwarsa");
            cmbStatus.SelectedIndex = 0;

            TampilData();
        }

        void TampilData()
        {
            SqlConnection conn = Koneksi.GetConnection();
            conn.Open();

            string query = "SELECT Bahan.Nama_bahan, Stok.Jumlah_bahan, Stok.Tanggal_masuk, Stok.Tanggal_kadaluwarsa, Stok.Status " +
                           "FROM Stok JOIN Bahan ON Stok.Id_bahan = Bahan.Id_bahan";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = Koneksi.GetConnection();
            conn.Open();

            string query = "SELECT Bahan.Nama_bahan, Stok.* FROM Stok " +
                           "JOIN Bahan ON Stok.Id_bahan = Bahan.Id_bahan " +
                           "WHERE Nama_bahan LIKE @search";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Koneksi.GetConnection();
            conn.Open();

            string query;

            if (cmbStatus.Text == "Semua")
                query = "SELECT * FROM Stok";
            else
                query = "SELECT * FROM Stok WHERE Status=@status";

            SqlCommand cmd = new SqlCommand(query, conn);

            if (cmbStatus.Text != "Semua")
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            TampilData();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            FormLaporan f = new FormLaporan();
            f.Show();
        }
    }
}
