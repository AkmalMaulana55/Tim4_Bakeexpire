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
            BindingSource bs = new BindingSource();
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
                dataGridView1.DataSource = dt;
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
                string query = "INSERT INTO Bahan (Nama_bahan, Kategori, Satuan) VALUES (@nama, @kat, @sat)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@kat", txtKategori.Text);
                cmd.Parameters.AddWithValue("@sat", txtSatuan.Text);
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
                string query = "UPDATE Bahan SET Nama_bahan=@nama, Kategori=@kat, Satuan=@sat WHERE Id_bahan=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@kat", txtKategori.Text);
                cmd.Parameters.AddWithValue("@sat", txtSatuan.Text);
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
                    string query = "DELETE FROM Bahan WHERE Id_bahan=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
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
    }
}
