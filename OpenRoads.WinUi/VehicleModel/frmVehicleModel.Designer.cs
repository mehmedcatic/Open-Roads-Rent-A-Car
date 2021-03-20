namespace OpenRoads.WinUI.VehicleModel
{
    partial class frmVehicleModel
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
            this.cmbManufacturers = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dgvVehicleModels = new System.Windows.Forms.DataGridView();
            this.TypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufacturerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufacturerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleModels)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvVehicleModels);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.cmbManufacturers);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1109, 582);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle models";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manufacturer:";
            // 
            // cmbManufacturers
            // 
            this.cmbManufacturers.FormattingEnabled = true;
            this.cmbManufacturers.Location = new System.Drawing.Point(124, 40);
            this.cmbManufacturers.Name = "cmbManufacturers";
            this.cmbManufacturers.Size = new System.Drawing.Size(223, 24);
            this.cmbManufacturers.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(403, 40);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(150, 24);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Apply filters";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvVehicleModels
            // 
            this.dgvVehicleModels.AllowUserToAddRows = false;
            this.dgvVehicleModels.AllowUserToDeleteRows = false;
            this.dgvVehicleModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicleModels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeId,
            this.ManufacturerId,
            this.TypeName,
            this.ManufacturerName});
            this.dgvVehicleModels.Location = new System.Drawing.Point(7, 104);
            this.dgvVehicleModels.Name = "dgvVehicleModels";
            this.dgvVehicleModels.ReadOnly = true;
            this.dgvVehicleModels.RowHeadersWidth = 51;
            this.dgvVehicleModels.RowTemplate.Height = 24;
            this.dgvVehicleModels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicleModels.Size = new System.Drawing.Size(1096, 472);
            this.dgvVehicleModels.TabIndex = 3;
            this.dgvVehicleModels.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
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
            // TypeName
            // 
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.HeaderText = "Name";
            this.TypeName.MinimumWidth = 6;
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            this.TypeName.Width = 125;
            // 
            // ManufacturerName
            // 
            this.ManufacturerName.DataPropertyName = "ManufacturerName";
            this.ManufacturerName.HeaderText = "Manufacturer name";
            this.ManufacturerName.MinimumWidth = 6;
            this.ManufacturerName.Name = "ManufacturerName";
            this.ManufacturerName.ReadOnly = true;
            this.ManufacturerName.Width = 125;
            // 
            // frmVehicleModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 607);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmVehicleModel";
            this.Text = "frmVehicleModel";
            this.Load += new System.EventHandler(this.frmVehicleModel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleModels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvVehicleModels;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufacturerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufacturerName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cmbManufacturers;
        private System.Windows.Forms.Label label1;
    }
}