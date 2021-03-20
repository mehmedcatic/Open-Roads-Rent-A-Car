namespace OpenRoads.WinUI.Rating
{
    partial class frmRating
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
            this.dgvRatings = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVehicle = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.RatingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatingInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatings)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.cmbVehicle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvRatings);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 612);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reviews:";
            // 
            // dgvRatings
            // 
            this.dgvRatings.AllowUserToAddRows = false;
            this.dgvRatings.AllowUserToDeleteRows = false;
            this.dgvRatings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRatings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RatingId,
            this.VehicleId,
            this.ClientId,
            this.ClientName,
            this.VehicleName,
            this.RatingInt,
            this.CreationDate,
            this.Comment});
            this.dgvRatings.Location = new System.Drawing.Point(6, 87);
            this.dgvRatings.Name = "dgvRatings";
            this.dgvRatings.ReadOnly = true;
            this.dgvRatings.RowHeadersWidth = 51;
            this.dgvRatings.RowTemplate.Height = 24;
            this.dgvRatings.Size = new System.Drawing.Size(996, 519);
            this.dgvRatings.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vehicle:";
            // 
            // cmbVehicle
            // 
            this.cmbVehicle.FormattingEnabled = true;
            this.cmbVehicle.Location = new System.Drawing.Point(71, 41);
            this.cmbVehicle.Name = "cmbVehicle";
            this.cmbVehicle.Size = new System.Drawing.Size(174, 24);
            this.cmbVehicle.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(315, 41);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(159, 24);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Apply Filters";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // RatingId
            // 
            this.RatingId.DataPropertyName = "RatingId";
            this.RatingId.HeaderText = "RatingId";
            this.RatingId.MinimumWidth = 6;
            this.RatingId.Name = "RatingId";
            this.RatingId.ReadOnly = true;
            this.RatingId.Visible = false;
            this.RatingId.Width = 125;
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
            // ClientName
            // 
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.HeaderText = "Client";
            this.ClientName.MinimumWidth = 6;
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            this.ClientName.Width = 125;
            // 
            // VehicleName
            // 
            this.VehicleName.DataPropertyName = "VehicleName";
            this.VehicleName.HeaderText = "Vehicle";
            this.VehicleName.MinimumWidth = 6;
            this.VehicleName.Name = "VehicleName";
            this.VehicleName.ReadOnly = true;
            this.VehicleName.Width = 125;
            // 
            // RatingInt
            // 
            this.RatingInt.DataPropertyName = "RatingInt";
            this.RatingInt.HeaderText = "Score";
            this.RatingInt.MinimumWidth = 6;
            this.RatingInt.Name = "RatingInt";
            this.RatingInt.ReadOnly = true;
            this.RatingInt.Width = 125;
            // 
            // CreationDate
            // 
            this.CreationDate.DataPropertyName = "CreationDate";
            this.CreationDate.HeaderText = "Created";
            this.CreationDate.MinimumWidth = 6;
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.ReadOnly = true;
            this.CreationDate.Width = 125;
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Comment";
            this.Comment.MinimumWidth = 6;
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            this.Comment.Width = 125;
            // 
            // frmRating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 636);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRating";
            this.Text = "frmRating";
            this.Load += new System.EventHandler(this.frmRating_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRatings;
        private System.Windows.Forms.ComboBox cmbVehicle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatingInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
    }
}