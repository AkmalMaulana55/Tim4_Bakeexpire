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
    public partial class FormCetakLaporan: Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dtLaporan;
        ReportLaporan reportLaporan = new ReportLaporan();
        public FormCetakLaporan()
        {
            InitializeComponent();

            try
            {
                conn = Koneksi.GetConnection();
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("sp_Report_Laporan", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter(cmd);
                dtLaporan = new DataTable();
                da.Fill(dtLaporan);

                conn.Close();

                reportLaporan.SetDataSource(dtLaporan);
                crystalReportViewer1.ReportSource = reportLaporan;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data: " + ex.Message);
            }
        }

        private void FormCetakLaporan_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is FormLaporan)
                {
                    f.Show();
                    break;
                }
            }
        }
    }
}
