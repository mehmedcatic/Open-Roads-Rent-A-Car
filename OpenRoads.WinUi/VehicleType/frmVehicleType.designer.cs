namespace OpenRoads.WinUI.VehicleType
{
    partial class frmVehicleType
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
            this.dgvVehicleType = new System.Windows.Forms.DataGridView();
            this.TypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleType)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVehicleType
            // 
            this.dgvVehicleType.AllowUserToAddRows = false;
            this.dgvVehicleType.AllowUserToDeleteRows = false;
            this.dgvVehicleType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicleType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeId,
            this.TypeName});
            this.dgvVehicleType.Location = new System.Drawing.Point(7, 42);
            this.dgvVehicleType.Name = "dgvVehicleType";
            this.dgvVehicleType.ReadOnly = true;
            this.dgvVehicleType.RowHeadersWidth = 51;
            this.dgvVehicleType.RowTemplate.Height = 24;
            this.dgvVehicleType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicleType.Size = new System.Drawing.Size(1061, 585);
            this.dgvVehicleType.TabIndex = 0;
            this.dgvVehicleType.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvVehicleTransmissionTypes_MouseDoubleClick);
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
            this.groupBox1.Controls.Add(this.dgvVehicleType);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1074, 633);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle types";
            // 
            // frmVehicleType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 648);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmVehicleType";
            this.Text = "frmVehicleType";
            this.Load += new System.EventHandler(this.frmVehicleType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleType)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVehicleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}