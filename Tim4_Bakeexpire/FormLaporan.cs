using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tim4_Bakeexpire
{
    public partial class FormLaporan: Form
    {
        int _userId;
        int selectedIdStok = 0;

        public FormLaporan(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void FormLaporan_Load(object sender, EventArgs e)
        {
            cmbTindakan.Items.Add("Restock");
            cmbTindakan.Items.Add("Promo");
            cmbTindakan.SelectedIndex = 0;

            LoadStokBermasalah();
            LoadRiwayatLaporan();
        }

        private void LoadStokBermasalah()
        {
            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();
                string query = @"SELECT s.Id_stok, b.Nama_bahan, s.Jumlah_bahan,
                                    s.Tanggal_kadaluwarsa, s.Status
                             FROM Stok s
                             JOIN Bahan b ON s.Id_bahan = b.Id_bahan
                             WHERE s.Status IN ('Hampir Kadaluwarsa', 'Kadaluwarsa')
                             ORDER BY s.Tanggal_kadaluwarsa ASC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStokBermasalah.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadRiwayatLaporan()
        {
            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();
                string query = @"SELECT l.Id_laporan, b.Nama_bahan, u.Nama as Petugas,
                                    l.Tindakan, l.Keterangan, l.Tanggal_laporan
                             FROM Laporan l
                             JOIN Stok s ON l.Id_stok = s.Id_stok
                             JOIN Bahan b ON s.Id_bahan = b.Id_bahan
                             JOIN Users u ON l.Id_user = u.Id_user
                             ORDER BY l.Tanggal_laporan DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLaporan.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvStokBermasalah_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedIdStok = Convert.ToInt32(dgvStokBermasalah.Rows[e.RowIndex].Cells["Id_stok"].Value);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (selectedIdStok == 0)
            {
                MessageBox.Show("Pilih stok dari tabel atas dulu!");
                return;
            }

            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();
                string query = @"INSERT INTO Laporan (Id_stok, Id_user, Tindakan, Keterangan, Tanggal_laporan)
                             VALUES (@idstok, @iduser, @tindakan, @ket, @tgl)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idstok", selectedIdStok);
                cmd.Parameters.AddWithValue("@iduser", _userId);
                cmd.Parameters.AddWithValue("@tindakan", cmbTindakan.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@ket", txtKeterangan.Text);
                cmd.Parameters.AddWithValue("@tgl", DateTime.Today);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Laporan berhasil disimpan!");
                txtKeterangan.Text = "";
                selectedIdStok = 0;
                LoadRiwayatLaporan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnHapusLaporan_Click(object sender, EventArgs e)
        {
            if (dgvLaporan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih laporan yang ingin dihapus dulu!");
                return;
            }

            int idLaporan = Convert.ToInt32(dgvLaporan.SelectedRows[0].Cells["Id_laporan"].Value);

            DialogResult confirm = MessageBox.Show(
                "Yakin ingin menghapus laporan ini?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    SqlConnection conn = Koneksi.GetConnection();
                    conn.Open();
                    string query = "DELETE FROM Laporan WHERE Id_laporan = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idLaporan);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Laporan berhasil dihapus!");
                    LoadRiwayatLaporan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
