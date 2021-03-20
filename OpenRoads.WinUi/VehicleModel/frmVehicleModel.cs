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

namespace OpenRoads.WinUI.VehicleModel
{
    public partial class frmVehicleModel : Form
    {
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");
        private readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");

        public frmVehicleModel()
        {
            InitializeComponent();
        }



        private class VehicleModelToDisplay
        {
            public int TypeId { get; set; }
            public int ManufacturerId { get; set; }
            public string TypeName { get; set; }
            public string ManufacturerName { get; set; }
        }

        private async Task LoadVehicleModels(int? manufacturerId = null)
        {
            if (manufacturerId.HasValue)
            {
                var request = new VehicleModelSearchRequest
                {
                    VehicleManufacturerId = manufacturerId
                };

                var vehicleModels = await _vehicleModelService.Get<List<VehicleModelModel>>(request);
                var manufacturer = await _vehicleManufacturerService.GetById<VehicleManufacturerModel>(manufacturerId);

                List<VehicleModelToDisplay> list = new List<VehicleModelToDisplay>();
                foreach (var x in vehicleModels)
                {
                    list.Add(new VehicleModelToDisplay
                    {
                        TypeName = x.Name,
                        ManufacturerId = x.VehicleManufacturerId,
                        ManufacturerName = manufacturer.Name,
                        TypeId = x.VehicleModelId
                    });
                }

                dgvVehicleModels.AutoGenerateColumns = false;
                dgvVehicleModels.DataSource = list;
            }
            else
            {
                var vehicleModels = await _vehicleModelService.Get<List<VehicleModelModel>>(null);
                var manufacturers = await _vehicleManufacturerService.Get<List<VehicleManufacturerModel>>(null);

                List<VehicleModelToDisplay> list = new List<VehicleModelToDisplay>();
                foreach (var x in vehicleModels)
                {
                    foreach (var y in manufacturers)
                    {
                        if (x.VehicleManufacturerId == y.VehicleManufacturerId)
                        {
                            list.Add(new VehicleModelToDisplay
                            {
                                TypeName = x.Name,
                                TypeId = x.VehicleModelId,
                                ManufacturerId = y.VehicleManufacturerId,
                                ManufacturerName = y.Name
                            });
                            break;
                        }
                    }
                }

                dgvVehicleModels.AutoGenerateColumns = false;
                dgvVehicleModels.DataSource = list;
            }
        }

        private async void frmVehicleModel_Load(object sender, EventArgs e)
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbManufacturers, _vehicleManufacturerService,
                WinFormModelTypesList.ModelTypes.VehicleManufacturerModel.ToString());

            await LoadVehicleModels();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var mId = cmbManufacturers.SelectedValue;
            if (int.TryParse(mId.ToString(), out int manufacturerId))
            {
                if (manufacturerId != 0)
                    await LoadVehicleModels(manufacturerId);
                else
                    await LoadVehicleModels();

            }
            
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var vehicleModelID = dgvVehicleModels.SelectedRows[0].Cells[0].Value;
            var vehicleManufacturerID = dgvVehicleModels.SelectedRows[0].Cells[1].Value;

            frmAddUpdateVehicleModel frm = new frmAddUpdateVehicleModel(int.Parse(vehicleModelID.ToString()),
                int.Parse(vehicleManufacturerID.ToString()));
            frm.Show();
        }
    }
}
