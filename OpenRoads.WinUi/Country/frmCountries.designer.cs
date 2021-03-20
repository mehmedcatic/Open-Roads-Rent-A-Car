namespace OpenRoads.WinUI.Country
{
    partial class frmCountries
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCountry = new System.Windows.Forms.DataGridView();
            this.CountryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCountry);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1055, 657);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Countries:";
            // 
            // dgvCountry
            // 
            this.dgvCountry.AllowUserToAddRows = false;
            this.dgvCountry.AllowUserToDeleteRows = false;
            this.dgvCountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCountry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CountryId,
            this.CountryName});
            this.dgvCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCountry.Location = new System.Drawing.Point(3, 18);
            this.dgvCountry.Name = "dgvCountry";
            this.dgvCountry.ReadOnly = true;
            this.dgvCountry.RowHeadersWidth = 51;
            this.dgvCountry.RowTemplate.Height = 24;
            this.dgvCountry.Size = new System.Drawing.Size(1049, 636);
            this.dgvCountry.TabIndex = 0;
            // 
            // CountryId
            // 
            this.CountryId.DataPropertyName = "CountryId";
            this.CountryId.HeaderText = "ID";
            this.CountryId.MinimumWidth = 6;
            this.CountryId.Name = "CountryId";
            this.CountryId.ReadOnly = true;
            this.CountryId.Width = 125;
            // 
            // CountryName
            // 
            this.CountryName.DataPropertyName = "Name";
            this.CountryName.HeaderText = "Name";
            this.CountryName.MinimumWidth = 6;
            this.CountryName.Name = "CountryName";
            this.CountryName.ReadOnly = true;
            this.CountryName.Width = 125;
            // 
            // frmCountries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 681);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCountries";
            this.Text = "frmCountries";
            this.Load += new System.EventHandler(this.frmCountries_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryName;
    }
}