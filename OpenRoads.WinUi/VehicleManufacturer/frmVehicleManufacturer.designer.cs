namespace OpenRoads.WinUI.VehicleManufacturer
{
    partial class frmVehicleManufacturer
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
            this.dgvVehicleManufacturers = new System.Windows.Forms.DataGridView();
            this.TypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleManufacturers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVehicleManufacturers
            // 
            this.dgvVehicleManufacturers.AllowUserToAddRows = false;
            this.dgvVehicleManufacturers.AllowUserToDeleteRows = false;
            this.dgvVehicleManufacturers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicleManufacturers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeId,
            this.TypeName});
            this.dgvVehicleManufacturers.Location = new System.Drawing.Point(7, 42);
            this.dgvVehicleManufacturers.Name = "dgvVehicleManufacturers";
            this.dgvVehicleManufacturers.ReadOnly = true;
            this.dgvVehicleManufacturers.RowHeadersWidth = 51;
            this.dgvVehicleManufacturers.RowTemplate.Height = 24;
            this.dgvVehicleManufacturers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicleManufacturers.Size = new System.Drawing.Size(1073, 586);
            this.dgvVehicleManufacturers.TabIndex = 0;
            this.dgvVehicleManufacturers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvVehicleManufacturers_MouseDoubleClick);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvVehicleManufacturers);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1086, 622);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle manufacturers:";
            // 
            // frmVehicleManufacturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 658);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmVehicleManufacturer";
            this.Text = "frmVehicleManufacturer";
            this.Load += new System.EventHandler(this.frmVehicleManufacturer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleManufacturers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVehicleManufacturers;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}