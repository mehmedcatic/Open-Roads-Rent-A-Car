namespace OpenRoads.WinUI.Vehicle
{
    partial class frmAddUpdateVehicle
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtManufacturedYear = new System.Windows.Forms.TextBox();
            this.txtDoors = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPowerHp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSeats = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRegistrationNr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbVehicleType = new System.Windows.Forms.ComboBox();
            this.cmbVehicleCategory = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbVehicleModel = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbFuelType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTransmissionType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtPictureInput = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manufactured year:";
            // 
            // txtManufacturedYear
            // 
            this.txtManufacturedYear.Location = new System.Drawing.Point(16, 47);
            this.txtManufacturedYear.Name = "txtManufacturedYear";
            this.txtManufacturedYear.Size = new System.Drawing.Size(213, 22);
            this.txtManufacturedYear.TabIndex = 1;
            this.txtManufacturedYear.Validating += new System.ComponentModel.CancelEventHandler(this.txtManufacturedYear_Validating);
            // 
            // txtDoors
            // 
            this.txtDoors.Location = new System.Drawing.Point(16, 101);
            this.txtDoors.Name = "txtDoors";
            this.txtDoors.Size = new System.Drawing.Size(213, 22);
            this.txtDoors.TabIndex = 3;
            this.txtDoors.Validating += new System.ComponentModel.CancelEventHandler(this.txtDoors_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Doors count:";
            // 
            // txtPowerHp
            // 
            this.txtPowerHp.Location = new System.Drawing.Point(276, 47);
            this.txtPowerHp.Name = "txtPowerHp";
            this.txtPowerHp.Size = new System.Drawing.Size(213, 22);
            this.txtPowerHp.TabIndex = 5;
            this.txtPowerHp.Validating += new System.ComponentModel.CancelEventHandler(this.txtPowerHp_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Power in HP:";
            // 
            // txtSeats
            // 
            this.txtSeats.Location = new System.Drawing.Point(276, 101);
            this.txtSeats.Name = "txtSeats";
            this.txtSeats.Size = new System.Drawing.Size(213, 22);
            this.txtSeats.TabIndex = 7;
            this.txtSeats.Validating += new System.ComponentModel.CancelEventHandler(this.txtSeats_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Seats count:";
            // 
            // txtRegistrationNr
            // 
            this.txtRegistrationNr.Location = new System.Drawing.Point(16, 161);
            this.txtRegistrationNr.Name = "txtRegistrationNr";
            this.txtRegistrationNr.Size = new System.Drawing.Size(213, 22);
            this.txtRegistrationNr.TabIndex = 9;
            this.txtRegistrationNr.Validating += new System.ComponentModel.CancelEventHandler(this.txtRegistrationNr_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Registration nr:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(276, 161);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(213, 22);
            this.txtPrice.TabIndex = 11;
            this.txtPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrice_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(273, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Price by day:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Vehicle type:";
            // 
            // cmbVehicleType
            // 
            this.cmbVehicleType.FormattingEnabled = true;
            this.cmbVehicleType.Location = new System.Drawing.Point(16, 222);
            this.cmbVehicleType.Name = "cmbVehicleType";
            this.cmbVehicleType.Size = new System.Drawing.Size(213, 24);
            this.cmbVehicleType.TabIndex = 13;
            this.cmbVehicleType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbVehicleType_Validating);
            // 
            // cmbVehicleCategory
            // 
            this.cmbVehicleCategory.FormattingEnabled = true;
            this.cmbVehicleCategory.Location = new System.Drawing.Point(276, 222);
            this.cmbVehicleCategory.Name = "cmbVehicleCategory";
            this.cmbVehicleCategory.Size = new System.Drawing.Size(213, 24);
            this.cmbVehicleCategory.TabIndex = 15;
            this.cmbVehicleCategory.Validating += new System.ComponentModel.CancelEventHandler(this.cmbVehicleCategory_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(273, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Vehicle category:";
            // 
            // cmbVehicleModel
            // 
            this.cmbVehicleModel.FormattingEnabled = true;
            this.cmbVehicleModel.Location = new System.Drawing.Point(16, 286);
            this.cmbVehicleModel.Name = "cmbVehicleModel";
            this.cmbVehicleModel.Size = new System.Drawing.Size(213, 24);
            this.cmbVehicleModel.TabIndex = 17;
            this.cmbVehicleModel.Validating += new System.ComponentModel.CancelEventHandler(this.cmbVehicleModel_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Vehicle model:";
            // 
            // cmbFuelType
            // 
            this.cmbFuelType.FormattingEnabled = true;
            this.cmbFuelType.Location = new System.Drawing.Point(276, 286);
            this.cmbFuelType.Name = "cmbFuelType";
            this.cmbFuelType.Size = new System.Drawing.Size(213, 24);
            this.cmbFuelType.TabIndex = 19;
            this.cmbFuelType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbFuelType_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Fuel type:";
            // 
            // cmbTransmissionType
            // 
            this.cmbTransmissionType.FormattingEnabled = true;
            this.cmbTransmissionType.Location = new System.Drawing.Point(16, 345);
            this.cmbTransmissionType.Name = "cmbTransmissionType";
            this.cmbTransmissionType.Size = new System.Drawing.Size(213, 24);
            this.cmbTransmissionType.TabIndex = 21;
            this.cmbTransmissionType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbTransmissionType_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 325);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "Transmission type:";
            // 
            // cmbBranch
            // 
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(276, 345);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(213, 24);
            this.cmbBranch.TabIndex = 23;
            this.cmbBranch.Validating += new System.ComponentModel.CancelEventHandler(this.cmbBranch_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(273, 325);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 17);
            this.label12.TabIndex = 22;
            this.label12.Text = "Branch:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(585, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 17);
            this.label13.TabIndex = 24;
            this.label13.Text = "Image:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(588, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(438, 209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // txtPictureInput
            // 
            this.txtPictureInput.Location = new System.Drawing.Point(588, 46);
            this.txtPictureInput.Name = "txtPictureInput";
            this.txtPictureInput.Size = new System.Drawing.Size(292, 22);
            this.txtPictureInput.TabIndex = 26;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSubmit.Location = new System.Drawing.Point(588, 336);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(438, 32);
            this.btnSubmit.TabIndex = 27;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAddImage.Location = new System.Drawing.Point(905, 46);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(121, 23);
            this.btnAddImage.TabIndex = 28;
            this.btnAddImage.Text = "Browse";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmAddUpdateVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 436);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtPictureInput);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbTransmissionType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbFuelType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbVehicleModel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbVehicleCategory);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbVehicleType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRegistrationNr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSeats);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPowerHp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDoors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtManufacturedYear);
            this.Controls.Add(this.label1);
            this.Name = "frmAddUpdateVehicle";
            this.Text = "frmAddUpdateVehicle";
            this.Load += new System.EventHandler(this.frmAddUpdateVehicle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtManufacturedYear;
        private System.Windows.Forms.TextBox txtDoors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPowerHp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSeats;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRegistrationNr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbVehicleType;
        private System.Windows.Forms.ComboBox cmbVehicleCategory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbVehicleModel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbFuelType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbTransmissionType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPictureInput;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}