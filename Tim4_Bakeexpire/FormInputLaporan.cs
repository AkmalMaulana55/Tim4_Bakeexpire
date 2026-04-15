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
    public partial class FormInputLaporan: Form
    {
        public FormInputLaporan()
        {
            InitializeComponent();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Koneksi.GetConnection();
            conn.Open();

            string query = "INSERT INTO Laporan (Id_stok, Id_user, Tindakan, Keterangan, Tanggal_laporan) " +
                           "VALUES (@stok, @user, @tindakan, @ket, @tgl)";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@stok", cmbStok.SelectedValue);
            cmd.Parameters.AddWithValue("@user", 1);
            cmd.Parameters.AddWithValue("@tindakan", cmbTindakan.Text);
            cmd.Parameters.AddWithValue("@ket", txtKeterangan.Text);
            cmd.Parameters.AddWithValue("@tgl", DateTime.Now);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Berhasil disimpan");
        }
    }
}
