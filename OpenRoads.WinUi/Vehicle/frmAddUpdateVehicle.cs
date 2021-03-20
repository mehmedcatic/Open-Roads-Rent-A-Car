using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using OpenRoads.Model.Requests;
using OpenRoads.WinUI.WFHelpers;

namespace OpenRoads.WinUI.Vehicle
{
    public partial class frmAddUpdateVehicle : Form
    {
        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");
        private readonly APIService _vehicleCategoryService = new APIService("VehicleCategory");
        private readonly APIService _vehicleTransmissionService = new APIService("VehicleTransmissionType");
        private readonly APIService _vehicleFuelService = new APIService("VehicleFuelType");
        private readonly APIService _vehicleTypeService = new APIService("VehicleType");
        private readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");
        private readonly APIService _branchService = new APIService("Branch");

        private int? _vehicleId = null;
        private int? _transmissionId = null;
        private int? _fuelId = null;
        private int? _manufacturerId = null;

        public frmAddUpdateVehicle(int? vehicleID = null, int? transmissionID = null, int? fuelID = null, int? manufacturerID = null)
        {
            InitializeComponent();
            _vehicleId = vehicleID;
            _transmissionId = transmissionID;
            _fuelId = fuelID;
            _manufacturerId = manufacturerID;
        }



        private async void frmAddUpdateVehicle_Load(object sender, EventArgs e)
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbBranch, _branchService,
                WinFormModelTypesList.ModelTypes.BranchModel.ToString());
            await VFormBaseMethods.LoadAssetToComboBox(cmbVehicleCategory, _vehicleCategoryService,
                WinFormModelTypesList.ModelTypes.VehicleCategoryModel.ToString());
            await VFormBaseMethods.LoadAssetToComboBox(cmbVehicleModel, _vehicleModelService,
                WinFormModelTypesList.ModelTypes.VehicleModelModel.ToString());
            await VFormBaseMethods.LoadAssetToComboBox(cmbFuelType, _vehicleFuelService,
                WinFormModelTypesList.ModelTypes.VehicleFuelTypeModel.ToString());
            await VFormBaseMethods.LoadAssetToComboBox(cmbTransmissionType, _vehicleTransmissionService,
                WinFormModelTypesList.ModelTypes.VehicleTransmissionTypeModel.ToString());
            await VFormBaseMethods.LoadAssetToComboBox(cmbVehicleType, _vehicleTypeService,
                WinFormModelTypesList.ModelTypes.VehicleTypeModel.ToString());


            if (_vehicleId.HasValue && _fuelId.HasValue && _manufacturerId.HasValue && _transmissionId.HasValue)
            {
                var vehicle = await _vehicleService.GetById<OpenRoads.Model.VehicleModel>(_vehicleId);
              
                txtPrice.Text = vehicle.PriceByDay.ToString();
                txtDoors.Text = vehicle.DoorsCount.ToString();
                txtPowerHp.Text = vehicle.PowerInHp.ToString();
                txtSeats.Text = vehicle.SeatsCount.ToString();
                txtRegistrationNr.Text = vehicle.RegistrationNumber;
                txtManufacturedYear.Text = vehicle.ManufacturedYear.ToString();
               
                if (vehicle.Picture.Length != 0)
                {
                   
                    if (vehicle.PictureThumb.Length > 0)
                    {
                        byte[] fileNameInBytes = vehicle.PictureThumb;
                        string pictureName = Encoding.Default.GetString(fileNameInBytes);
                        txtPictureInput.Text = pictureName;
                    }
                    else
                    {
                        txtPictureInput.Text = "";
                    }

                    request.Picture = vehicle.Picture;
                    request.PictureThumb = vehicle.PictureThumb;

                    MemoryStream ms = new MemoryStream(vehicle.Picture, 0, vehicle.Picture.Length);
                    ms.Write(vehicle.Picture, 0, vehicle.Picture.Length);
                    Image returnImage = Image.FromStream(ms, true);

                    pictureBox1.Image = returnImage;
                }

                cmbBranch.SelectedValue = vehicle.BranchId;
                cmbVehicleCategory.SelectedValue = vehicle.VehicleCategoryId;
                cmbVehicleType.SelectedValue = vehicle.VehicleTypeId;
                cmbFuelType.SelectedValue = vehicle.VehicleFuelTypeId;
                cmbTransmissionType.SelectedValue = vehicle.VehicleTransmissionTypeId;
                cmbVehicleModel.SelectedValue = vehicle.VehicleModelId;
                
            }
        }

        VehicleInsertUpdateRequest request = new VehicleInsertUpdateRequest();

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var brId = cmbBranch.SelectedValue;
                int.TryParse(brId.ToString(), out int branchId);

                var cId = cmbVehicleCategory.SelectedValue;
                int.TryParse(cId.ToString(), out int categoryId);

                var vmId = cmbVehicleModel.SelectedValue;
                int.TryParse(vmId.ToString(), out int vehicleModelId);

                var vtId = cmbVehicleType.SelectedValue;
                int.TryParse(vtId.ToString(), out int vehicleTypeId);

                var ftId = cmbFuelType.SelectedValue;
                int.TryParse(ftId.ToString(), out int fuelTypeId);

                var ttId = cmbTransmissionType.SelectedValue;
                int.TryParse(ttId.ToString(), out int transmissionTypeId);

                request.VehicleFuelTypeId = fuelTypeId;
                request.BranchId = branchId;
                request.VehicleModelId = vehicleModelId;
                request.VehicleTransmissionTypeId = transmissionTypeId;
                request.VehicleCategoryId = categoryId;
                request.VehicleTypeId = vehicleTypeId;
                request.Active = true;
                request.Available = true;
                request.PowerInHp = int.Parse(txtPowerHp.Text);
                request.SeatsCount = int.Parse(txtSeats.Text);
                request.DoorsCount = int.Parse(txtDoors.Text);
                request.PriceByDay = float.Parse(txtPrice.Text);
                request.RegistrationNumber = txtRegistrationNr.Text;
                request.ManufacturedYear = int.Parse(txtManufacturedYear.Text);


                OpenRoads.Model.VehicleModel vehicle = null;

                if (_vehicleId.HasValue && _fuelId.HasValue && _manufacturerId.HasValue && _transmissionId.HasValue)
                {
                    vehicle = await _vehicleService.Update<OpenRoads.Model.VehicleModel>(int.Parse(_vehicleId.ToString()), request);
                }
                else
                {
                    vehicle = await _vehicleService.Insert<OpenRoads.Model.VehicleModel>(request);
                }

                if (vehicle != null)
                {
                    MessageBox.Show("Success!");
                    if (Form.ActiveForm != null)
                        Form.ActiveForm.Close(); ;
                }
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "Image files(*.jpeg)|*.jpeg";
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);

                string fileName2 = fileName;
                string textFile = fileName.Substring(fileName2.LastIndexOf('\u005c')+1);
                
                request.Picture = file;
                request.PictureThumb = Encoding.Default.GetBytes(textFile);
                txtPictureInput.Text = textFile;

                Image img = Image.FromFile(fileName);
                pictureBox1.Image = img;
            }
        }





        private void txtManufacturedYear_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtManufacturedYear, e, errorProvider1, true);
        }

        private void txtPowerHp_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtPowerHp, e, errorProvider1, true);
        }

        private void txtDoors_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtDoors, e, errorProvider1, true);
        }

        private void txtSeats_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtSeats, e, errorProvider1, true);
        }

        private void txtRegistrationNr_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtRegistrationNr, e, errorProvider1);
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtPrice, e, errorProvider1, true);
        }

        private void cmbVehicleType_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateComboBox(cmbVehicleType, e, errorProvider1);
        }

        private void cmbVehicleCategory_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateComboBox(cmbVehicleCategory, e, errorProvider1);
        }

        private void cmbVehicleModel_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateComboBox(cmbVehicleModel, e, errorProvider1);
        }

        private void cmbFuelType_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateComboBox(cmbFuelType, e, errorProvider1);
        }

        private void cmbTransmissionType_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateComboBox(cmbTransmissionType, e, errorProvider1);
        }

        private void cmbBranch_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateComboBox(cmbBranch, e, errorProvider1);
        }
    }
}
