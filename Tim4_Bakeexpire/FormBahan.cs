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
    public partial class FormBahan : Form
    {
        int selectedId = 0;

        BindingSource bs = new BindingSource();

        public FormBahan()
        {
            InitializeComponent();
        }

        private void FormBahan_Load(object sender, EventArgs e)
        {
            LoadBahan();
            bindingNavigator1.BindingSource = bs;
        }

        private void LoadBahan()
        {
            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_bahan", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (txtNama.Text == "")
            {
                MessageBox.Show("Nama bahan harus diisi!");
                return;
            }

            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_tambah_bahan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@kategori", txtKategori.Text);
                cmd.Parameters.AddWithValue("@satuan", txtSatuan.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Bahan berhasil ditambahkan!");
                Bersihkan();
                LoadBahan();
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
                MessageBox.Show("Pilih bahan yang ingin diedit!");
                return;
            }

            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_edit_bahan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@kategori", txtKategori.Text);
                cmd.Parameters.AddWithValue("@satuan", txtSatuan.Text);
                cmd.Parameters.AddWithValue("@id", selectedId);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Bahan berhasil diupdate!");
                Bersihkan();
                LoadBahan();
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
                MessageBox.Show("Pilih bahan yang ingin dihapus!");
                return;
            }

            DialogResult konfirmasi = MessageBox.Show("Yakin hapus bahan ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (konfirmasi == DialogResult.Yes)
            {
                try
                {
                    SqlConnection conn = Koneksi.GetConnection();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_hapus_bahan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", selectedId);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Bahan berhasil dihapus!");
                    Bersihkan();
                    LoadBahan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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
            txtNama.Text = "";
            txtKategori.Text = "";
            txtSatuan.Text = "";
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["Id_bahan"].Value);
                txtNama.Text = row.Cells["Nama_bahan"].Value.ToString();
                txtKategori.Text = row.Cells["Kategori"].Value.ToString();
                txtSatuan.Text = row.Cells["Satuan"].Value.ToString();
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_search_bahan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@keyword", txtCari.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";
            ofd.Title = "Pilih File Excel Data Bahan";

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string filePath = ofd.FileName;
            int sukses = 0;
            int gagal = 0;
            int dilewati = 0;
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

                            string nama = reader.GetValue(0) == null ? "" : reader.GetValue(0).ToString().Trim();
                            string kategori = reader.GetValue(1) == null ? "" : reader.GetValue(1).ToString().Trim();
                            string satuan = reader.GetValue(2) == null ? "" : reader.GetValue(2).ToString().Trim();

                            if (string.IsNullOrWhiteSpace(nama))
                            {
                                continue;
                            }

                            try
                            {
                                // validasi huruf doang, sama kayak di form manual
                                if (CekHurufSaja(nama) == false || CekHurufSaja(kategori) == false || CekHurufSaja(satuan) == false)
                                {
                                    gagal++;
                                    pesanGagal.Add("Baris " + rowKe + ": ada angka/simbol, cuma boleh huruf");
                                    continue;
                                }

                                // cek dulu biar gak dobel kayak yang kemarin
                                SqlCommand cmdCek = new SqlCommand("SELECT COUNT(*) FROM Bahan WHERE Nama_bahan = @nama", conn);
                                cmdCek.Parameters.AddWithValue("@nama", nama);
                                int jumlahSama = (int)cmdCek.ExecuteScalar();

                                if (jumlahSama > 0)
                                {
                                    dilewati++;
                                    continue;
                                }

                                SqlCommand cmd = new SqlCommand("sp_tambah_bahan", conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@nama", nama);
                                cmd.Parameters.AddWithValue("@kategori", kategori);
                                cmd.Parameters.AddWithValue("@satuan", satuan);
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

                string ringkasan = "Import selesai!\nBerhasil: " + sukses +
                                    "\nDilewati (sudah ada): " + dilewati +
                                    "\nGagal: " + gagal;
                if (gagal > 0)
                {
                    ringkasan += "\n\nDetail gagal:\n" + string.Join("\n", pesanGagal);
                }

                MessageBox.Show(ringkasan);

                LoadBahan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal import: " + ex.Message);
            }
        }

        private bool CekHurufSaja(string teks)
        {
            foreach (char c in teks)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }
    }
}