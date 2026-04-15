using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tim4_Bakeexpire
{
    public partial class FormLaporan: Form
    {
        public FormLaporan()
        {
            InitializeComponent();
        }

        private void FormLaporan_Load(object sender, EventArgs e)
        {
            cmbFilter.Items.Add("Semua");
            cmbFilter.Items.Add("Hampir Kadaluwarsa");
            cmbFilter.Items.Add("Kadaluwarsa");
            cmbFilter.SelectedIndex = 0;

            TampilLaporan();
        }
    }
}
