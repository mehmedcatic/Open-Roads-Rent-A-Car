namespace OpenRoads.WinUI.Reservation
{
    partial class frmReservationMoreData
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.txtVehicleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInsuranceName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAdditionalInfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.cbCanceled = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpCreationDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client name:";
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(16, 42);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(240, 22);
            this.txtClientName.TabIndex = 1;
            // 
            // txtVehicleName
            // 
            this.txtVehicleName.Location = new System.Drawing.Point(298, 42);
            this.txtVehicleName.Name = "txtVehicleName";
            this.txtVehicleName.Size = new System.Drawing.Size(240, 22);
            this.txtVehicleName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vehicle name:";
            // 
            // txtInsuranceName
            // 
            this.txtInsuranceName.Location = new System.Drawing.Point(16, 101);
            this.txtInsuranceName.Name = "txtInsuranceName";
            this.txtInsuranceName.Size = new System.Drawing.Size(240, 22);
            this.txtInsuranceName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Insurance type:";
            // 
            // txtAdditionalInfo
            // 
            this.txtAdditionalInfo.Location = new System.Drawing.Point(298, 101);
            this.txtAdditionalInfo.Multiline = true;
            this.txtAdditionalInfo.Name = "txtAdditionalInfo";
            this.txtAdditionalInfo.Size = new System.Drawing.Size(240, 141);
            this.txtAdditionalInfo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Additional info:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(16, 159);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(240, 22);
            this.txtPrice.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total price:";
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(16, 221);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(68, 21);
            this.cbActive.TabIndex = 10;
            this.cbActive.Text = "Active";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // cbCanceled
            // 
            this.cbCanceled.AutoSize = true;
            this.cbCanceled.Location = new System.Drawing.Point(167, 221);
            this.cbCanceled.Name = "cbCanceled";
            this.cbCanceled.Size = new System.Drawing.Size(89, 21);
            this.cbCanceled.TabIndex = 11;
            this.cbCanceled.Text = "Canceled";
            this.cbCanceled.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Start date:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(19, 297);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(237, 22);
            this.dtpStartDate.TabIndex = 13;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(301, 297);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(237, 22);
            this.dtpEndDate.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "End date:";
            // 
            // dtpCreationDate
            // 
            this.dtpCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreationDate.Location = new System.Drawing.Point(19, 372);
            this.dtpCreationDate.Name = "dtpCreationDate";
            this.dtpCreationDate.Size = new System.Drawing.Size(237, 22);
            this.dtpCreationDate.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Reservation creation date:";
            // 
            // frmReservationMoreData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 453);
            this.Controls.Add(this.dtpCreationDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbCanceled);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAdditionalInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInsuranceName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVehicleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.label1);
            this.Name = "frmReservationMoreData";
            this.Text = "frmReservationMoreData";
            this.Load += new System.EventHandler(this.frmReservationMoreData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.TextBox txtVehicleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInsuranceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAdditionalInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.CheckBox cbCanceled;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpCreationDate;
        private System.Windows.Forms.Label label8;
    }
}