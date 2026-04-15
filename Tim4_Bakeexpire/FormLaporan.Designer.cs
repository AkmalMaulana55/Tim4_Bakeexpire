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
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.dataGridViewLaporan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLaporan)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(228, 77);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(121, 24);
            this.cmbFilter.TabIndex = 0;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(169, 108);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "button1";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(250, 107);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "button2";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnLaporan
            // 
            this.btnLaporan.Location = new System.Drawing.Point(331, 107);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(75, 23);
            this.btnLaporan.TabIndex = 3;
            this.btnLaporan.Text = "button3";
            this.btnLaporan.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLaporan
            // 
            this.dataGridViewLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLaporan.Location = new System.Drawing.Point(169, 137);
            this.dataGridViewLaporan.Name = "dataGridViewLaporan";
            this.dataGridViewLaporan.RowHeadersWidth = 51;
            this.dataGridViewLaporan.RowTemplate.Height = 24;
            this.dataGridViewLaporan.Size = new System.Drawing.Size(237, 150);
            this.dataGridViewLaporan.TabIndex = 4;
            // 
            // FormLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewLaporan);
            this.Controls.Add(this.btnLaporan);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cmbFilter);
            this.Name = "FormLaporan";
            this.Text = "FormLaporan";
            this.Load += new System.EventHandler(this.FormLaporan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLaporan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLaporan;
        private System.Windows.Forms.DataGridView dataGridViewLaporan;
    }
}