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
    public partial class FormDashboard: Form
    {
        int _userId;
        string _nama, _role;
        public FormDashboard(int userId, string nama, string role)
        {
            InitializeComponent();
            _userId = userId;
            _nama = nama;
            _role = role;
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Selamat Datang, " + _nama;
            lblRole.Text = "Role: " + _role;

            // Karyawan tidak bisa akses laporan
            if (_role == "Karyawan")
                btnLaporan.Enabled = false;

            UpdateStatus();
            LoadRingkasan();
        }

        private void UpdateStatus()
        {
            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();
                string query = @"UPDATE Stok SET Status =
                CASE
                    WHEN DATEDIFF(day, GETDATE(), Tanggal_kadaluwarsa) < 0 THEN 'Kadaluwarsa'
                    WHEN DATEDIFF(day, GETDATE(), Tanggal_kadaluwarsa) <= 7 THEN 'Hampir Kadaluwarsa'
                    ELSE 'Aman'
                END";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error update status: " + ex.Message);
            }
        }
        private void LoadRingkasan()
        {
            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();

                string q1 = "SELECT COUNT(*) FROM Stok WHERE Status='Aman'";
                string q2 = "SELECT COUNT(*) FROM Stok WHERE Status='Hampir Kadaluwarsa'";
                string q3 = "SELECT COUNT(*) FROM Stok WHERE Status='Kadaluwarsa'";

                lblAman.Text = "Aman: " + new SqlCommand(q1, conn).ExecuteScalar();
                lblHampir.Text = "Hampir Kadaluwarsa: " + new SqlCommand(q2, conn).ExecuteScalar();
                lblKadaluwarsa.Text = "Kadaluwarsa: " + new SqlCommand(q3, conn).ExecuteScalar();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBahan_Click(object sender, EventArgs e)
        {
            new FormBahan().Show();
        }

        private void btnStok_Click(object sender, EventArgs e)
        {
            new FormStok(_userId).Show();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            new FormLaporan(_userId).Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new FormLogin().Show();
        }
    }
}
