namespace OpenRoads.WinUI.Insurance
{
    partial class frmInsurance
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
            this.dgvInsurance = new System.Windows.Forms.DataGridView();
            this.InsuranceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsuranceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsurance)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvInsurance);
            this.groupBox1.Location = new System.Drawing.Point(24, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 639);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Insurance:";
            // 
            // dgvInsurance
            // 
            this.dgvInsurance.AllowUserToAddRows = false;
            this.dgvInsurance.AllowUserToDeleteRows = false;
            this.dgvInsurance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsurance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InsuranceId,
            this.InsuranceName,
            this.Price});
            this.dgvInsurance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInsurance.Location = new System.Drawing.Point(3, 18);
            this.dgvInsurance.Name = "dgvInsurance";
            this.dgvInsurance.ReadOnly = true;
            this.dgvInsurance.RowHeadersWidth = 51;
            this.dgvInsurance.RowTemplate.Height = 24;
            this.dgvInsurance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsurance.Size = new System.Drawing.Size(1022, 618);
            this.dgvInsurance.TabIndex = 0;
            this.dgvInsurance.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvInsurance_MouseDoubleClick);
            // 
            // InsuranceId
            // 
            this.InsuranceId.DataPropertyName = "InsuranceId";
            this.InsuranceId.HeaderText = "InsuranceId";
            this.InsuranceId.MinimumWidth = 6;
            this.InsuranceId.Name = "InsuranceId";
            this.InsuranceId.ReadOnly = true;
            this.InsuranceId.Visible = false;
            this.InsuranceId.Width = 125;
            // 
            // InsuranceName
            // 
            this.InsuranceName.DataPropertyName = "Name";
            this.InsuranceName.HeaderText = "Name";
            this.InsuranceName.MinimumWidth = 6;
            this.InsuranceName.Name = "InsuranceName";
            this.InsuranceName.ReadOnly = true;
            this.InsuranceName.Width = 125;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 125;
            // 
            // frmInsurance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 675);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmInsurance";
            this.Text = "frmInsurance";
            this.Load += new System.EventHandler(this.frmInsurance_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsurance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvInsurance;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsuranceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsuranceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}