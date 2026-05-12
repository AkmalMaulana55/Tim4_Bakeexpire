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
    public partial class FormStok: Form
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
                SqlCommand cmd = new SqlCommand("sp_tambah_stok",conn);
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
                SqlCommand cmd = new SqlCommand("sp_edit_stok",conn);
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
                    SqlCommand cmd = new SqlCommand("sp_hapus_stok",conn);
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
    }
}
