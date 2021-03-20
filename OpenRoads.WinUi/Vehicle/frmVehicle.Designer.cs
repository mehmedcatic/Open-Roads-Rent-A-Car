namespace OpenRoads.WinUI.Vehicle
{
    partial class frmVehicle
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
            this.dgvVehicle = new System.Windows.Forms.DataGridView();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cmbFuel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTransmission = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VehicleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransmissionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuelTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufacturerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuelType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransmissionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufacturerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvVehicle);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.cmbFuel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbManufacturer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbTransmission);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1465, 685);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicles";
            // 
            // dgvVehicle
            // 
            this.dgvVehicle.AllowUserToAddRows = false;
            this.dgvVehicle.AllowUserToDeleteRows = false;
            this.dgvVehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VehicleId,
            this.TransmissionId,
            this.FuelTypeId,
            this.ManufacturerId,
            this.VehicleName,
            this.FuelType,
            this.TransmissionType,
            this.ManufacturerName,
            this.Active,
            this.Delete});
            this.dgvVehicle.Location = new System.Drawing.Point(7, 139);
            this.dgvVehicle.Name = "dgvVehicle";
            this.dgvVehicle.ReadOnly = true;
            this.dgvVehicle.RowHeadersWidth = 51;
            this.dgvVehicle.RowTemplate.Height = 24;
            this.dgvVehicle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicle.Size = new System.Drawing.Size(1441, 540);
            this.dgvVehicle.TabIndex = 9;
            this.dgvVehicle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehicle_CellContentClick);
            this.dgvVehicle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvVehicle_MouseDoubleClick);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(812, 85);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(187, 31);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Apply filters";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cmbFuel
            // 
            this.cmbFuel.FormattingEnabled = true;
            this.cmbFuel.Location = new System.Drawing.Point(462, 34);
            this.cmbFuel.Name = "cmbFuel";
            this.cmbFuel.Size = new System.Drawing.Size(188, 24);
            this.cmbFuel.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fuel type:";
            // 
            // cmbManufacturer
            // 
            this.cmbManufacturer.FormattingEnabled = true;
            this.cmbManufacturer.Location = new System.Drawing.Point(811, 34);
            this.cmbManufacturer.Name = "cmbManufacturer";
            this.cmbManufacturer.Size = new System.Drawing.Size(188, 24);
            this.cmbManufacturer.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(695, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Manufacturer:";
            // 
            // cmbTransmission
            // 
            this.cmbTransmission.FormattingEnabled = true;
            this.cmbTransmission.Location = new System.Drawing.Point(123, 37);
            this.cmbTransmission.Name = "cmbTransmission";
            this.cmbTransmission.Size = new System.Drawing.Size(188, 24);
            this.cmbTransmission.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transmission:";
            // 
            // VehicleId
            // 
            this.VehicleId.DataPropertyName = "VehicleId";
            this.VehicleId.HeaderText = "VehicleId";
            this.VehicleId.MinimumWidth = 6;
            this.VehicleId.Name = "VehicleId";
            this.VehicleId.ReadOnly = true;
            this.VehicleId.Visible = false;
            this.VehicleId.Width = 125;
            // 
            // TransmissionId
            // 
            this.TransmissionId.DataPropertyName = "TransmissionId";
            this.TransmissionId.HeaderText = "TransmissionId";
            this.TransmissionId.MinimumWidth = 6;
            this.TransmissionId.Name = "TransmissionId";
            this.TransmissionId.ReadOnly = true;
            this.TransmissionId.Visible = false;
            this.TransmissionId.Width = 125;
            // 
            // FuelTypeId
            // 
            this.FuelTypeId.DataPropertyName = "FuelTypeId";
            this.FuelTypeId.HeaderText = "FuelTypeId";
            this.FuelTypeId.MinimumWidth = 6;
            this.FuelTypeId.Name = "FuelTypeId";
            this.FuelTypeId.ReadOnly = true;
            this.FuelTypeId.Visible = false;
            this.FuelTypeId.Width = 125;
            // 
            // ManufacturerId
            // 
            this.ManufacturerId.DataPropertyName = "ManufacturerId";
            this.ManufacturerId.HeaderText = "ManufacturerId";
            this.ManufacturerId.MinimumWidth = 6;
            this.ManufacturerId.Name = "ManufacturerId";
            this.ManufacturerId.ReadOnly = true;
            this.ManufacturerId.Visible = false;
            this.ManufacturerId.Width = 125;
            // 
            // VehicleName
            // 
            this.VehicleName.DataPropertyName = "VehicleName";
            this.VehicleName.HeaderText = "Vehicle name";
            this.VehicleName.MinimumWidth = 6;
            this.VehicleName.Name = "VehicleName";
            this.VehicleName.ReadOnly = true;
            this.VehicleName.Width = 125;
            // 
            // FuelType
            // 
            this.FuelType.DataPropertyName = "FuelTypeName";
            this.FuelType.HeaderText = "Fuel type";
            this.FuelType.MinimumWidth = 6;
            this.FuelType.Name = "FuelType";
            this.FuelType.ReadOnly = true;
            this.FuelType.Width = 125;
            // 
            // TransmissionType
            // 
            this.TransmissionType.DataPropertyName = "TransmissionName";
            this.TransmissionType.HeaderText = "Transmission";
            this.TransmissionType.MinimumWidth = 6;
            this.TransmissionType.Name = "TransmissionType";
            this.TransmissionType.ReadOnly = true;
            this.TransmissionType.Width = 125;
            // 
            // ManufacturerName
            // 
            this.ManufacturerName.DataPropertyName = "ManufacturerName";
            this.ManufacturerName.HeaderText = "Manufacturer";
            this.ManufacturerName.MinimumWidth = 6;
            this.ManufacturerName.Name = "ManufacturerName";
            this.ManufacturerName.ReadOnly = true;
            this.ManufacturerName.Width = 125;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.MinimumWidth = 6;
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Active.Width = 125;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete vehicle";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 125;
            // 
            // frmVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1489, 709);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmVehicle";
            this.Text = "frmVehicle";
            this.Load += new System.EventHandler(this.frmVehicle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbFuel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbManufacturer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTransmission;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgvVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransmissionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufacturerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransmissionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufacturerName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}