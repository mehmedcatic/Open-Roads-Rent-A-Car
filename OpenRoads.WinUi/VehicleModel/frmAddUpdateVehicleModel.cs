using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using OpenRoads.WinUI;
using OpenRoads.WinUI.WFHelpers;

namespace OpenRoads.WinUI.VehicleModel
{
    public partial class frmAddUpdateVehicleModel : Form
    {
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");
        private readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");

        private int? _vehicleModelId = null;
        private int? _vehicleManufacturerId = null;

        public frmAddUpdateVehicleModel(int? vehicleModelId = null, int? vehicleManufacturerId = null)
        {
            InitializeComponent();
            _vehicleModelId = vehicleModelId;
            _vehicleManufacturerId = vehicleManufacturerId;
        }



        private async void frmAddUpdateVehicleModel_Load(object sender, EventArgs e)
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbManufacturer, _vehicleManufacturerService,
                WinFormModelTypesList.ModelTypes.VehicleManufacturerModel.ToString());

            if (_vehicleModelId.HasValue && _vehicleManufacturerId.HasValue)
            {
                var modelObj =
                    await _vehicleModelService.GetById<VehicleModelModel>(int.Parse(_vehicleModelId.ToString()));
                var manufacturerObj =
                    await _vehicleManufacturerService.GetById<VehicleManufacturerModel>(
                        int.Parse(_vehicleManufacturerId.ToString()));

                txtName.Text = modelObj.Name;
                cmbManufacturer.SelectedValue = manufacturerObj.VehicleManufacturerId;
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var mId = cmbManufacturer.SelectedValue;
                int.TryParse(mId.ToString(), out int manufacturerId);

                var request = new VehicleModelAddUpdateRequest
                {
                    VehicleManufacturerId = manufacturerId,
                    Name = txtName.Text
                };

                VehicleModelModel modelObj = null;

                if (_vehicleModelId.HasValue && _vehicleManufacturerId.HasValue)
                    modelObj = await _vehicleModelService.Update<VehicleModelModel>(_vehicleModelId.Value, request);

                else
                {
                    modelObj = await _vehicleModelService.Insert<VehicleModelModel>(request);
                }

                if (modelObj != null)
                {
                    MessageBox.Show("Success!");
                    Form.ActiveForm.Close();
                }
            }
        }



        private void cmbManufacturer_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateComboBox(cmbManufacturer, e, errorProvider1);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtName, e, errorProvider1);
        }
    }
}
