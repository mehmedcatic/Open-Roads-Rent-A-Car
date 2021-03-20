namespace OpenRoads.WinUI.EmployeeRoles
{
    partial class frmEmployeeRoles
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
            this.dgvEmployeeRoles = new System.Windows.Forms.DataGridView();
            this.EmployeeRolesId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RolesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvEmployeeRoles);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 606);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Roles";
            // 
            // dgvEmployeeRoles
            // 
            this.dgvEmployeeRoles.AllowUserToAddRows = false;
            this.dgvEmployeeRoles.AllowUserToDeleteRows = false;
            this.dgvEmployeeRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeRolesId,
            this.RolesName,
            this.Description});
            this.dgvEmployeeRoles.Location = new System.Drawing.Point(7, 43);
            this.dgvEmployeeRoles.Name = "dgvEmployeeRoles";
            this.dgvEmployeeRoles.ReadOnly = true;
            this.dgvEmployeeRoles.RowHeadersWidth = 51;
            this.dgvEmployeeRoles.RowTemplate.Height = 24;
            this.dgvEmployeeRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeRoles.Size = new System.Drawing.Size(995, 557);
            this.dgvEmployeeRoles.TabIndex = 0;
            this.dgvEmployeeRoles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvEmployeeRoles_MouseDoubleClick);
            // 
            // EmployeeRolesId
            // 
            this.EmployeeRolesId.DataPropertyName = "EmployeeRolesId";
            this.EmployeeRolesId.HeaderText = "EmployeeRolesId";
            this.EmployeeRolesId.MinimumWidth = 6;
            this.EmployeeRolesId.Name = "EmployeeRolesId";
            this.EmployeeRolesId.ReadOnly = true;
            this.EmployeeRolesId.Visible = false;
            this.EmployeeRolesId.Width = 125;
            // 
            // RolesName
            // 
            this.RolesName.DataPropertyName = "RolesName";
            this.RolesName.HeaderText = "Name";
            this.RolesName.MinimumWidth = 6;
            this.RolesName.Name = "RolesName";
            this.RolesName.ReadOnly = true;
            this.RolesName.Width = 125;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 125;
            // 
            // frmEmployeeRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 631);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEmployeeRoles";
            this.Text = "frmEmployeeRoles";
            this.Load += new System.EventHandler(this.frmEmployeeRoles_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvEmployeeRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeRolesId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RolesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}