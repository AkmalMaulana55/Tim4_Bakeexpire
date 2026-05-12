namespace Tim4_Bakeexpire
{
    partial class FormDashboard
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblAman = new System.Windows.Forms.Label();
            this.lblHampir = new System.Windows.Forms.Label();
            this.lblKadaluwarsa = new System.Windows.Forms.Label();
            this.btnBahan = new System.Windows.Forms.Button();
            this.btnStok = new System.Windows.Forms.Button();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(455, 49);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(152, 16);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Selamat Datang, [nama]";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(499, 81);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(73, 16);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Role: [role]";
            // 
            // lblAman
            // 
            this.lblAman.AutoSize = true;
            this.lblAman.Location = new System.Drawing.Point(512, 210);
            this.lblAman.Name = "lblAman";
            this.lblAman.Size = new System.Drawing.Size(52, 16);
            this.lblAman.TabIndex = 2;
            this.lblAman.Text = "Aman:0";
            // 
            // lblHampir
            // 
            this.lblHampir.AutoSize = true;
            this.lblHampir.Location = new System.Drawing.Point(465, 238);
            this.lblHampir.Name = "lblHampir";
            this.lblHampir.Size = new System.Drawing.Size(142, 16);
            this.lblHampir.TabIndex = 3;
            this.lblHampir.Text = "Hampir Kadaluwarsa:0";
            // 
            // lblKadaluwarsa
            // 
            this.lblKadaluwarsa.AutoSize = true;
            this.lblKadaluwarsa.Location = new System.Drawing.Point(487, 271);
            this.lblKadaluwarsa.Name = "lblKadaluwarsa";
            this.lblKadaluwarsa.Size = new System.Drawing.Size(95, 16);
            this.lblKadaluwarsa.TabIndex = 4;
            this.lblKadaluwarsa.Text = "Kadaluwarsa:0";
            // 
            // btnBahan
            // 
            this.btnBahan.Location = new System.Drawing.Point(382, 118);
            this.btnBahan.Name = "btnBahan";
            this.btnBahan.Size = new System.Drawing.Size(142, 37);
            this.btnBahan.TabIndex = 5;
            this.btnBahan.Text = "Kelola Bahan";
            this.btnBahan.UseVisualStyleBackColor = true;
            this.btnBahan.Click += new System.EventHandler(this.btnBahan_Click);
            // 
            // btnStok
            // 
            this.btnStok.Location = new System.Drawing.Point(541, 118);
            this.btnStok.Name = "btnStok";
            this.btnStok.Size = new System.Drawing.Size(142, 37);
            this.btnStok.TabIndex = 6;
            this.btnStok.Text = "Kelola Stok";
            this.btnStok.UseVisualStyleBackColor = true;
            this.btnStok.Click += new System.EventHandler(this.btnStok_Click);
            // 
            // btnLaporan
            // 
            this.btnLaporan.Location = new System.Drawing.Point(414, 161);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(75, 34);
            this.btnLaporan.TabIndex = 7;
            this.btnLaporan.Text = "Laporan";
            this.btnLaporan.UseVisualStyleBackColor = true;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(578, 161);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 34);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 591);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLaporan);
            this.Controls.Add(this.btnStok);
            this.Controls.Add(this.btnBahan);
            this.Controls.Add(this.lblKadaluwarsa);
            this.Controls.Add(this.lblHampir);
            this.Controls.Add(this.lblAman);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblWelcome);
            this.Name = "FormDashboard";
            this.Text = "FormDashboard";
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblAman;
        private System.Windows.Forms.Label lblHampir;
        private System.Windows.Forms.Label lblKadaluwarsa;
        private System.Windows.Forms.Button btnBahan;
        private System.Windows.Forms.Button btnStok;
        private System.Windows.Forms.Button btnLaporan;
        private System.Windows.Forms.Button btnLogout;
    }
}