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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (email == "" || pass == "")
            {
                MessageBox.Show("Email dan password harus diisi!");
                return;
            }

            try
            {
                SqlConnection conn = Koneksi.GetConnection();
                conn.Open();

                string query =
                    "SELECT * FROM Users WHERE Email='"
                    + email +
                    "' AND Password='"
                    + pass +
                    "'";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["Id_user"]);
                    string nama = reader["Nama"].ToString();
                    string role = reader["Role"].ToString();
                    reader.Close();
                    conn.Close();

                    MessageBox.Show("Selamat datang, " + nama + "!");
                    FormDashboard dashboard = new FormDashboard(userId, nama, role);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Email atau password salah!");
                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}