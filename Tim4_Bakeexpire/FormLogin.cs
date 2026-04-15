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
    public partial class FormLogin: Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Harus diisi!");
                return;
            }

            SqlConnection conn = Koneksi.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Users WHERE Email=@email AND Password=@pass";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                MessageBox.Show("Login berhasil");

                FormMonitoring f = new FormMonitoring();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login gagal");
            }
        }
    }
}
