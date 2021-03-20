namespace OpenRoads.WinUI.VehicleTransmissionType
{
    partial class frmVehicleTransmissionType
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
            this.dgvVehicleTransmissionTypes = new System.Windows.Forms.DataGridView();
            this.TypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleTransmissionTypes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVehicleTransmissionTypes
            // 
            this.dgvVehicleTransmissionTypes.AllowUserToAddRows = false;
            this.dgvVehicleTransmissionTypes.AllowUserToDeleteRows = false;
            this.dgvVehicleTransmissionTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicleTransmissionTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeId,
            this.TypeName});
            this.dgvVehicleTransmissionTypes.Location = new System.Drawing.Point(7, 42);
            this.dgvVehicleTransmissionTypes.Name = "dgvVehicleTransmissionTypes";
            this.dgvVehicleTransmissionTypes.ReadOnly = true;
            this.dgvVehicleTransmissionTypes.RowHeadersWidth = 51;
            this.dgvVehicleTransmissionTypes.RowTemplate.Height = 24;
            this.dgvVehicleTransmissionTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicleTransmissionTypes.Size = new System.Drawing.Size(1061, 585);
            this.dgvVehicleTransmissionTypes.TabIndex = 0;
            this.dgvVehicleTransmissionTypes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvVehicleTransmissionTypes_MouseDoubleClick);
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
            this.groupBox1.Controls.Add(this.dgvVehicleTransmissionTypes);
            this.groupBox1.Location = new System.Drawing.Point(9, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1074, 633);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle transmission types";
            // 
            // frmVehicleTransmissionType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 658);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmVehicleTransmissionType";
            this.Text = "frmVehicleTransmissionType";
            this.Load += new System.EventHandler(this.frmVehicleTransmissionType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleTransmissionTypes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVehicleTransmissionTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}