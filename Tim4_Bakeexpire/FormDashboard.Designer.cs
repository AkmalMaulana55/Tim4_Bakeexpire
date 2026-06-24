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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblAman = new System.Windows.Forms.Label();
            this.lblHampir = new System.Windows.Forms.Label();
            this.lblKadaluwarsa = new System.Windows.Forms.Label();
            this.btnBahan = new System.Windows.Forms.Button();
            this.btnStok = new System.Windows.Forms.Button();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.chartStok = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartStok)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(455, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(152, 16);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Selamat Datang, [nama]";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(499, 41);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(73, 16);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Role: [role]";
            // 
            // lblAman
            // 
            this.lblAman.AutoSize = true;
            this.lblAman.Location = new System.Drawing.Point(511, 464);
            this.lblAman.Name = "lblAman";
            this.lblAman.Size = new System.Drawing.Size(52, 16);
            this.lblAman.TabIndex = 2;
            this.lblAman.Text = "Aman:0";
            // 
            // lblHampir
            // 
            this.lblHampir.AutoSize = true;
            this.lblHampir.Location = new System.Drawing.Point(464, 492);
            this.lblHampir.Name = "lblHampir";
            this.lblHampir.Size = new System.Drawing.Size(142, 16);
            this.lblHampir.TabIndex = 3;
            this.lblHampir.Text = "Hampir Kadaluwarsa:0";
            // 
            // lblKadaluwarsa
            // 
            this.lblKadaluwarsa.AutoSize = true;
            this.lblKadaluwarsa.Location = new System.Drawing.Point(486, 525);
            this.lblKadaluwarsa.Name = "lblKadaluwarsa";
            this.lblKadaluwarsa.Size = new System.Drawing.Size(95, 16);
            this.lblKadaluwarsa.TabIndex = 4;
            this.lblKadaluwarsa.Text = "Kadaluwarsa:0";
            // 
            // btnBahan
            // 
            this.btnBahan.Location = new System.Drawing.Point(382, 78);
            this.btnBahan.Name = "btnBahan";
            this.btnBahan.Size = new System.Drawing.Size(142, 37);
            this.btnBahan.TabIndex = 5;
            this.btnBahan.Text = "Kelola Bahan";
            this.btnBahan.UseVisualStyleBackColor = true;
            this.btnBahan.Click += new System.EventHandler(this.btnBahan_Click);
            // 
            // btnStok
            // 
            this.btnStok.Location = new System.Drawing.Point(541, 78);
            this.btnStok.Name = "btnStok";
            this.btnStok.Size = new System.Drawing.Size(142, 37);
            this.btnStok.TabIndex = 6;
            this.btnStok.Text = "Kelola Stok";
            this.btnStok.UseVisualStyleBackColor = true;
            this.btnStok.Click += new System.EventHandler(this.btnStok_Click);
            // 
            // btnLaporan
            // 
            this.btnLaporan.Location = new System.Drawing.Point(414, 121);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(75, 34);
            this.btnLaporan.TabIndex = 7;
            this.btnLaporan.Text = "Laporan";
            this.btnLaporan.UseVisualStyleBackColor = true;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(578, 121);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 34);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // chartStok
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStok.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStok.Legends.Add(legend1);
            this.chartStok.Location = new System.Drawing.Point(241, 161);
            this.chartStok.Name = "chartStok";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartStok.Series.Add(series1);
            this.chartStok.Size = new System.Drawing.Size(571, 300);
            this.chartStok.TabIndex = 9;
            this.chartStok.Text = "chart1";
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 591);
            this.Controls.Add(this.chartStok);
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
            ((System.ComponentModel.ISupportInitialize)(this.chartStok)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStok;
    }
}