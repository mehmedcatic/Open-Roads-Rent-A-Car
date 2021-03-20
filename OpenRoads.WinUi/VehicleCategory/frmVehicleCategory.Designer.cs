namespace OpenRoads.WinUI.VehicleCategory
{
    partial class frmVehicleCategory
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
            this.dgvVehicleCategories = new System.Windows.Forms.DataGridView();
            this.TypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvVehicleCategories);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1074, 633);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle categories";
            // 
            // dgvVehicleCategories
            // 
            this.dgvVehicleCategories.AllowUserToAddRows = false;
            this.dgvVehicleCategories.AllowUserToDeleteRows = false;
            this.dgvVehicleCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicleCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeId,
            this.TypeName});
            this.dgvVehicleCategories.Location = new System.Drawing.Point(7, 42);
            this.dgvVehicleCategories.Name = "dgvVehicleCategories";
            this.dgvVehicleCategories.ReadOnly = true;
            this.dgvVehicleCategories.RowHeadersWidth = 51;
            this.dgvVehicleCategories.RowTemplate.Height = 24;
            this.dgvVehicleCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicleCategories.Size = new System.Drawing.Size(1061, 585);
            this.dgvVehicleCategories.TabIndex = 0;
            this.dgvVehicleCategories.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvVehicleCategories_MouseDoubleClick);
            // 
            // TypeId
            // 
            this.TypeId.DataPropertyName = "TypeId";
            this.TypeId.HeaderText = "TypeId";
            this.TypeId.MinimumWidth = 6;
            this.TypeId.Name = "TypeId";
            this.TypeId.ReadOnly = true;
            this.TypeId.Visible = false;
            this.TypeId.Width = 125;
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.HeaderText = "Name";
            this.TypeName.MinimumWidth = 6;
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            this.TypeName.Width = 125;
            // 
            // frmVehicleCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 658);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmVehicleCategory";
            this.Text = "frmVehicleCategory";
            this.Load += new System.EventHandler(this.frmVehicleCategory_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvVehicleCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
    }
}