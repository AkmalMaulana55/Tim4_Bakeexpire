namespace Tim4_Bakeexpire
{
    partial class FormLaporan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTindakan = new System.Windows.Forms.ComboBox();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapusLaporan = new System.Windows.Forms.Button();
            this.dgvStokBermasalah = new System.Windows.Forms.DataGridView();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStokBermasalah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tindakan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Keterangan";
            // 
            // cmbTindakan
            // 
            this.cmbTindakan.FormattingEnabled = true;
            this.cmbTindakan.Location = new System.Drawing.Point(133, 34);
            this.cmbTindakan.Name = "cmbTindakan";
            this.cmbTindakan.Size = new System.Drawing.Size(193, 24);
            this.cmbTindakan.TabIndex = 2;
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(133, 69);
            this.txtKeterangan.Multiline = true;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(193, 48);
            this.txtKeterangan.TabIndex = 3;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(393, 34);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(134, 37);
            this.btnSimpan.TabIndex = 4;
            this.btnSimpan.Text = "Simpan Laporan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnHapusLaporan
            // 
            this.btnHapusLaporan.Location = new System.Drawing.Point(393, 80);
            this.btnHapusLaporan.Name = "btnHapusLaporan";
            this.btnHapusLaporan.Size = new System.Drawing.Size(134, 37);
            this.btnHapusLaporan.TabIndex = 5;
            this.btnHapusLaporan.Text = "Hapus Laporan";
            this.btnHapusLaporan.UseVisualStyleBackColor = true;
            this.btnHapusLaporan.Click += new System.EventHandler(this.btnHapusLaporan_Click);
            // 
            // dgvStokBermasalah
            // 
            this.dgvStokBermasalah.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStokBermasalah.Location = new System.Drawing.Point(12, 135);
            this.dgvStokBermasalah.Name = "dgvStokBermasalah";
            this.dgvStokBermasalah.RowHeadersWidth = 51;
            this.dgvStokBermasalah.RowTemplate.Height = 24;
            this.dgvStokBermasalah.Size = new System.Drawing.Size(628, 471);
            this.dgvStokBermasalah.TabIndex = 6;
            this.dgvStokBermasalah.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStokBermasalah_CellContentClick);
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Location = new System.Drawing.Point(646, 135);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.RowHeadersWidth = 51;
            this.dgvLaporan.RowTemplate.Height = 24;
            this.dgvLaporan.Size = new System.Drawing.Size(564, 471);
            this.dgvLaporan.TabIndex = 7;
            // 
            // FormLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 618);
            this.Controls.Add(this.dgvLaporan);
            this.Controls.Add(this.dgvStokBermasalah);
            this.Controls.Add(this.btnHapusLaporan);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.cmbTindakan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormLaporan";
            this.Text = "FormLaporan";
            this.Load += new System.EventHandler(this.FormLaporan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStokBermasalah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTindakan;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapusLaporan;
        private System.Windows.Forms.DataGridView dgvStokBermasalah;
        private System.Windows.Forms.DataGridView dgvLaporan;
    }
}