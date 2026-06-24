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
using ExcelDataReader;
using System.IO;

namespace Tim4_Bakeexpire
{
    public partial class FormStok : Form
    {
        int _userId;
        int selectedId = 0;

        BindingSource bs = new BindingSource();

        public FormStok(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void FormStok_Load(object sender, EventArgs e)
        {
            LoadComboBoxBahan();
            LoadStok();
            bindingNavigator1.BindingSource = bs;
            dtpKadaluwarsa.ValueChanged += new EventHandler(dtpKadaluwarsa_ValueChanged);
        }

        private void LoadComboBoxBahan()
        {
            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id_bahan, Nama_bahan FROM Bahan", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbBahan.DataSource = dt;
                cmbBahan.DisplayMember = "Nama_bahan";
                cmbBahan.ValueMember = "Id_bahan";
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadStok()
        {
            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();
                string query = "SELECT * FROM vw_stok";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
                conn.Close();
                WarnaiStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void WarnaiStatus()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    if (status == "Kadaluwarsa")
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                    else if (status == "Hampir Kadaluwarsa")
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    else
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                }
            }
        }

        private string HitungStatus(DateTime tglKadaluwarsa)
        {
            int selisih = (tglKadaluwarsa - DateTime.Today).Days;
            if (selisih < 0) return "Kadaluwarsa";
            if (selisih <= 7) return "Hampir Kadaluwarsa";
            return "Aman";
        }

        private void dtpKadaluwarsa_ValueChanged(object sender, EventArgs e)
        {
            lblStatus.Text = HitungStatus(dtpKadaluwarsa.Value);
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (txtJumlah.Text == "")
            {
                MessageBox.Show("Jumlah harus diisi!");
                return;
            }

            string status = HitungStatus(dtpKadaluwarsa.Value);

            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_tambah_stok", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idbahan", cmbBahan.SelectedValue);
                cmd.Parameters.AddWithValue("@iduser", _userId);
                cmd.Parameters.AddWithValue("@jumlah", Convert.ToDouble(txtJumlah.Text));
                cmd.Parameters.AddWithValue("@masuk", dtpMasuk.Value.Date);
                cmd.Parameters.AddWithValue("@kadaluwarsa", dtpKadaluwarsa.Value.Date);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Stok berhasil ditambahkan!");
                Bersihkan();
                LoadStok();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Pilih stok yang ingin diedit!");
                return;
            }

            string status = HitungStatus(dtpKadaluwarsa.Value);

            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_edit_stok", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idbahan", cmbBahan.SelectedValue);
                cmd.Parameters.AddWithValue("@jumlah", Convert.ToDouble(txtJumlah.Text));
                cmd.Parameters.AddWithValue("@masuk", dtpMasuk.Value.Date);
                cmd.Parameters.AddWithValue("@kadaluwarsa", dtpKadaluwarsa.Value.Date);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", selectedId);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Stok berhasil diupdate!");
                Bersihkan();
                LoadStok();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Pilih stok yang ingin dihapus!");
                return;
            }

            DialogResult konfirmasi = MessageBox.Show("Yakin hapus stok ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (konfirmasi == DialogResult.Yes)
            {
                try
                {
                    SqlConnection conn = Koneksi.GetConnection();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_hapus_stok", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", selectedId);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Stok berhasil dihapus!");
                    Bersihkan();
                    LoadStok();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["Id_stok"].Value);
                txtJumlah.Text = row.Cells["Jumlah_bahan"].Value.ToString();
                dtpMasuk.Value = Convert.ToDateTime(row.Cells["Tanggal_masuk"].Value);
                dtpKadaluwarsa.Value = Convert.ToDateTime(row.Cells["Tanggal_kadaluwarsa"].Value);
                lblStatus.Text = row.Cells["Status"].Value.ToString();

                // Arahkan combobox ke bahan yang sesuai
                string namaBahan = row.Cells["Nama_bahan"].Value.ToString();
                foreach (DataRowView item in cmbBahan.Items)
                {
                    if (item["Nama_bahan"].ToString() == namaBahan)
                    {
                        cmbBahan.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void btnBersih_Click(object sender, EventArgs e)
        {
            Bersihkan();
        }

        private void Bersihkan()
        {
            selectedId = 0;
            txtJumlah.Text = "";
            lblStatus.Text = "";
            dtpMasuk.Value = DateTime.Today;
            dtpKadaluwarsa.Value = DateTime.Today;
            if (cmbBahan.Items.Count > 0) cmbBahan.SelectedIndex = 0;
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";
            ofd.Title = "Pilih File Excel Stok Bahan";

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string filePath = ofd.FileName;
            int sukses = 0;
            int gagal = 0;
            List<string> pesanGagal = new List<string>();

            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();

                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        int rowKe = 0;

                        while (reader.Read())
                        {
                            rowKe++;

                            // baris 1 dianggap header, skip
                            if (rowKe == 1)
                            {
                                continue;
                            }

                            string namaBahan = reader.GetValue(0) == null ? "" : reader.GetValue(0).ToString().Trim();

                            if (string.IsNullOrWhiteSpace(namaBahan))
                            {
                                continue;
                            }

                            try
                            {
                                int idBahan = CariAtauTambahBahan(conn, namaBahan);

                                double jumlah = Convert.ToDouble(reader.GetValue(1));
                                DateTime tglMasuk = Convert.ToDateTime(reader.GetValue(2));
                                DateTime tglKadaluwarsa = Convert.ToDateTime(reader.GetValue(3));
                                string status = HitungStatus(tglKadaluwarsa);

                                SqlCommand cmd = new SqlCommand("sp_tambah_stok", conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@idbahan", idBahan);
                                cmd.Parameters.AddWithValue("@iduser", _userId);
                                cmd.Parameters.AddWithValue("@jumlah", jumlah);
                                cmd.Parameters.AddWithValue("@masuk", tglMasuk);
                                cmd.Parameters.AddWithValue("@kadaluwarsa", tglKadaluwarsa);
                                cmd.Parameters.AddWithValue("@status", status);
                                cmd.ExecuteNonQuery();

                                sukses++;
                            }
                            catch (Exception exBaris)
                            {
                                gagal++;
                                pesanGagal.Add("Baris " + rowKe + ": " + exBaris.Message);
                            }
                        }
                    }
                }

                conn.Close();

                string ringkasan = "Import selesai!\nBerhasil: " + sukses + "\nGagal: " + gagal;
                if (gagal > 0)
                {
                    ringkasan += "\n\nDetail gagal:\n" + string.Join("\n", pesanGagal);
                }

                MessageBox.Show(ringkasan);

                LoadComboBoxBahan();
                LoadStok();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal import: " + ex.Message);
            }
        }

        private int CariAtauTambahBahan(SqlConnection conn, string namaBahan)
        {
            SqlCommand cmdCek = new SqlCommand("SELECT Id_bahan FROM Bahan WHERE Nama_bahan = @nama", conn);
            cmdCek.Parameters.AddWithValue("@nama", namaBahan);
            object hasil = cmdCek.ExecuteScalar();

            if (hasil != null)
            {
                return Convert.ToInt32(hasil);
            }

            SqlCommand cmdTambah = new SqlCommand("sp_tambah_bahan", conn);
            cmdTambah.CommandType = CommandType.StoredProcedure;
            cmdTambah.Parameters.AddWithValue("@nama", namaBahan);
            cmdTambah.Parameters.AddWithValue("@kategori", "Lainnya");
            cmdTambah.Parameters.AddWithValue("@satuan", "pcs");
            cmdTambah.ExecuteNonQuery();

            SqlCommand cmdAmbilId = new SqlCommand("SELECT Id_bahan FROM Bahan WHERE Nama_bahan = @nama", conn);
            cmdAmbilId.Parameters.AddWithValue("@nama", namaBahan);
            return Convert.ToInt32(cmdAmbilId.ExecuteScalar());
        }
    }
}