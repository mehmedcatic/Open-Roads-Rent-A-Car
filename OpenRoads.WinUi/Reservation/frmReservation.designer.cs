namespace OpenRoads.WinUI.Reservation
{
    partial class frmReservation
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVehicle = new System.Windows.Forms.ComboBox();
            this.cmbInsurance = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.ReservationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsuranceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleModelManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReservationPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsuranceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvReservations);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.cmbInsurance);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbVehicle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1060, 566);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reservations:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vehicle:";
            // 
            // cmbVehicle
            // 
            this.cmbVehicle.FormattingEnabled = true;
            this.cmbVehicle.Location = new System.Drawing.Point(81, 34);
            this.cmbVehicle.Name = "cmbVehicle";
            this.cmbVehicle.Size = new System.Drawing.Size(238, 24);
            this.cmbVehicle.TabIndex = 1;
            // 
            // cmbInsurance
            // 
            this.cmbInsurance.FormattingEnabled = true;
            this.cmbInsurance.Location = new System.Drawing.Point(439, 34);
            this.cmbInsurance.Name = "cmbInsurance";
            this.cmbInsurance.Size = new System.Drawing.Size(238, 24);
            this.cmbInsurance.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Insurance:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(731, 34);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(153, 24);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Apply filters";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvReservations
            // 
            this.dgvReservations.AllowUserToAddRows = false;
            this.dgvReservations.AllowUserToDeleteRows = false;
            this.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReservationId,
            this.ClientId,
            this.VehicleId,
            this.InsuranceId,
            this.ClientName,
            this.VehicleModelManufacturer,
            this.ReservationPrice,
            this.InsuranceName,
            this.Active});
            this.dgvReservations.Location = new System.Drawing.Point(0, 92);
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.ReadOnly = true;
            this.dgvReservations.RowHeadersWidth = 51;
            this.dgvReservations.RowTemplate.Height = 24;
            this.dgvReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservations.Size = new System.Drawing.Size(1060, 468);
            this.dgvReservations.TabIndex = 5;
            this.dgvReservations.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvReservations_MouseDoubleClick);
            // 
            // ReservationId
            // 
            this.ReservationId.DataPropertyName = "ReservationId";
            this.ReservationId.HeaderText = "ReservationId";
            this.ReservationId.MinimumWidth = 6;
            this.ReservationId.Name = "ReservationId";
            this.ReservationId.ReadOnly = true;
            this.ReservationId.Visible = false;
            this.ReservationId.Width = 125;
            // 
            // ClientId
            // 
            this.ClientId.DataPropertyName = "ClientId";
            this.ClientId.HeaderText = "ClientId";
            this.ClientId.MinimumWidth = 6;
            this.ClientId.Name = "ClientId";
            this.ClientId.ReadOnly = true;
            this.ClientId.Visible = false;
            this.ClientId.Width = 125;
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
            // ClientName
            // 
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.HeaderText = "Client";
            this.ClientName.MinimumWidth = 6;
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            this.ClientName.Width = 125;
            // 
            // VehicleModelManufacturer
            // 
            this.VehicleModelManufacturer.DataPropertyName = "VehicleModelManufacturer";
            this.VehicleModelManufacturer.HeaderText = "Vehicle";
            this.VehicleModelManufacturer.MinimumWidth = 6;
            this.VehicleModelManufacturer.Name = "VehicleModelManufacturer";
            this.VehicleModelManufacturer.ReadOnly = true;
            this.VehicleModelManufacturer.Width = 125;
            // 
            // ReservationPrice
            // 
            this.ReservationPrice.DataPropertyName = "ReservationPrice";
            this.ReservationPrice.HeaderText = "Reservation price";
            this.ReservationPrice.MinimumWidth = 6;
            this.ReservationPrice.Name = "ReservationPrice";
            this.ReservationPrice.ReadOnly = true;
            this.ReservationPrice.Width = 125;
            // 
            // InsuranceName
            // 
            this.InsuranceName.DataPropertyName = "InsuranceName";
            this.InsuranceName.HeaderText = "Insurance type";
            this.InsuranceName.MinimumWidth = 6;
            this.InsuranceName.Name = "InsuranceName";
            this.InsuranceName.ReadOnly = true;
            this.InsuranceName.Width = 125;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.MinimumWidth = 6;
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Width = 125;
            // 
            // frmReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 599);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReservation";
            this.Text = "frmReservation";
            this.Load += new System.EventHandler(this.frmReservation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cmbInsurance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVehicle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsuranceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleModelManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservationPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsuranceName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
    }
}