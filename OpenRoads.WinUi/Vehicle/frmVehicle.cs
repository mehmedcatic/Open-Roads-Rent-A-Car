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
using OpenRoads.WinUI.WFHelpers;

namespace OpenRoads.WinUI.Vehicle
{
    public partial class frmVehicle : Form
    {
        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _vehicleTransmissionService = new APIService("VehicleTransmissionType");
        private readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");
        private readonly APIService _vehicleFuelTypeService = new APIService("VehicleFuelType");
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");


        public frmVehicle()
        {
            InitializeComponent();
        }




        private async void frmVehicle_Load(object sender, EventArgs e)
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbManufacturer, _vehicleManufacturerService,
                WinFormModelTypesList.ModelTypes.VehicleManufacturerModel.ToString());
            await VFormBaseMethods.LoadAssetToComboBox(cmbFuel, _vehicleFuelTypeService,
                WinFormModelTypesList.ModelTypes.VehicleFuelTypeModel.ToString());
            await VFormBaseMethods.LoadAssetToComboBox(cmbTransmission, _vehicleTransmissionService,
                WinFormModelTypesList.ModelTypes.VehicleTransmissionTypeModel.ToString());

            await LoadVehicles();
        }

        private List<VehicleToDisplay> GenerateResult(List<OpenRoads.Model.VehicleModel> vehicles,
            List<VehicleManufacturerModel> manufacturers, List<VehicleFuelTypeModel> fuelTypes,
            List<VehicleTransmissionTypeModel> transmissionTypes, List<VehicleModelModel> models)
        {
            List<VehicleToDisplay> result = new List<VehicleToDisplay>();

            foreach (var x in vehicles)
            {
                VehicleToDisplay newVehicle = new VehicleToDisplay();

                newVehicle.Active = x.Active;
                newVehicle.VehicleId = x.VehicleId;

                foreach (var y in fuelTypes)
                {
                    if (x.VehicleFuelTypeId == y.VehicleFuelTypeId)
                    {
                        newVehicle.FuelTypeId = y.VehicleFuelTypeId;
                        newVehicle.FuelTypeName = y.Name;
                        break;
                    }
                }

                foreach (var z in transmissionTypes)
                {
                    if (x.VehicleTransmissionTypeId == z.VehicleTransmissionTypeId)
                    {
                        newVehicle.TransmissionId = z.VehicleTransmissionTypeId;
                        newVehicle.TransmissionName = z.Name;
                        break;
                    }
                }

                foreach (var model in models)
                {
                    if (x.VehicleModelId == model.VehicleModelId)
                    {
                        newVehicle.VehicleName = model.Name;

                        foreach (var manufacturer in manufacturers)
                        {
                            if (model.VehicleManufacturerId == manufacturer.VehicleManufacturerId)
                            {
                                newVehicle.ManufacturerName = manufacturer.Name;
                                newVehicle.ManufacturerId = manufacturer.VehicleManufacturerId;
                                break;
                            }
                        }
                    }
                }
                result.Add(newVehicle);
            }

            return result;
        }

        private async Task LoadVehicles(int? manufacturerId = 0, int? fuelId = 0, int? transmissionId = 0)
        {
            var manufacturerList = await _vehicleManufacturerService.Get<List<VehicleManufacturerModel>>(null);
            var fuelList = await _vehicleFuelTypeService.Get<List<VehicleFuelTypeModel>>(null);
            var transmissionList = await _vehicleTransmissionService.Get<List<VehicleTransmissionTypeModel>>(null);
            var modelsList = await _vehicleModelService.Get<List<VehicleModelModel>>(null);

            if (manufacturerId != 0 || fuelId != 0 || transmissionId != 0)
            {
                var request = new VehicleSearchRequest();
                if (manufacturerId != 0)
                    request.VehicleManufacturerId = manufacturerId;
                if (fuelId != 0)
                    request.VehicleFuelTypeId = fuelId;
                if (transmissionId != 0)
                    request.VehicleTransmissionTypeId = transmissionId;

                var vehicleList = await _vehicleService.Get<List<OpenRoads.Model.VehicleModel>>(request);

                var result = GenerateResult(vehicleList, manufacturerList, fuelList, transmissionList, modelsList);

                dgvVehicle.AutoGenerateColumns = false;
                dgvVehicle.DataSource = result;
            }
            else
            {
                var vehicleList = await _vehicleService.Get<List<OpenRoads.Model.VehicleModel>>(null);

                var result = GenerateResult(vehicleList, manufacturerList, fuelList, transmissionList, modelsList);

                dgvVehicle.AutoGenerateColumns = false;
                dgvVehicle.DataSource = result;
            }
        }

        private class VehicleToDisplay
        {
            public int VehicleId { get; set; }
            public int ManufacturerId { get; set; }
            public int TransmissionId { get; set; }
            public int FuelTypeId { get; set; }
            public string VehicleName { get; set; }
            public string FuelTypeName { get; set; }
            public string TransmissionName { get; set; }
            public string ManufacturerName { get; set; }
            public bool Active { get; set; }
        }


        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var mId = cmbManufacturer.SelectedValue;
            var fId = cmbFuel.SelectedValue;
            var tId = cmbTransmission.SelectedValue;

            int.TryParse(mId.ToString(), out int manufacturerId);
            int.TryParse(fId.ToString(), out int fuelId);
            int.TryParse(tId.ToString(), out int transmissionId);

            if (manufacturerId != 0 && fuelId != 0 && transmissionId != 0)
                await LoadVehicles(manufacturerId, fuelId, transmissionId);
            if (manufacturerId != 0 && fuelId != 0 && transmissionId == 0)
                await LoadVehicles(manufacturerId, fuelId, 0);
            if (manufacturerId != 0 && fuelId == 0 && transmissionId != 0)
                await LoadVehicles(manufacturerId, 0, transmissionId);
            if (manufacturerId == 0 && fuelId != 0 && transmissionId != 0)
                await LoadVehicles(0, fuelId, transmissionId);
            if (manufacturerId != 0 && fuelId == 0 && transmissionId == 0)
                await LoadVehicles(manufacturerId, 0, 0);
            if (manufacturerId == 0 && fuelId != 0 && transmissionId == 0)
                await LoadVehicles(0, fuelId, 0);
            if (manufacturerId == 0 && fuelId == 0 && transmissionId != 0)
                await LoadVehicles(0, 0, transmissionId);
            if (manufacturerId == 0 && fuelId == 0 && transmissionId == 0)
                await LoadVehicles();
        }

        private void dgvVehicle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var vehicleID = dgvVehicle.SelectedRows[0].Cells[0].Value;
            var transmissionID = dgvVehicle.SelectedRows[0].Cells[1].Value;
            var fuelID = dgvVehicle.SelectedRows[0].Cells[2].Value;
            var manufacturerID = dgvVehicle.SelectedRows[0].Cells[3].Value;

            frmAddUpdateVehicle frm = new frmAddUpdateVehicle(int.Parse(vehicleID.ToString()), int.Parse(transmissionID.ToString()),
                int.Parse(fuelID.ToString()), int.Parse(manufacturerID.ToString()));
            frm.Show();
        }

        private async void dgvVehicle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = await VFormBaseMethods.DeleteContentOnCellClick<OpenRoads.Model.VehicleModel>(dgvVehicle, e,
                WinFormModelTypesList.ModelTypes.VehicleModel.ToString());
            if (result != null)
                await LoadVehicles();
        }
    }
}
