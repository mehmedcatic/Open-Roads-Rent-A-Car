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
using OpenRoads.WinUI.WFHelpers;

namespace OpenRoads.WinUI.VehicleManufacturer
{
    public partial class frmVehicleManufacturer : Form
    {
        private readonly APIService _service = new APIService("VehicleManufacturer");

        public frmVehicleManufacturer()
        {
            InitializeComponent();
        }

        private async void frmVehicleManufacturer_Load(object sender, EventArgs e)
        {
            var objects = await _service.Get<List<VehicleManufacturerModel>>(null);

            VFormBaseMethods.baseFormForVehicleReferenceModelsLoad(
                WinFormModelTypesList.ModelTypes.VehicleManufacturerModel, dgvVehicleManufacturers, new List<VehicleCategoryModel>(),
                new List<VehicleFuelTypeModel>(), new List<VehicleTypeModel>(), objects,
                new List<VehicleTransmissionTypeModel>());
        }

        private void dgvVehicleManufacturers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VFormBaseMethods.MouseDoubleClick(WinFormModelTypesList.ModelTypes.VehicleManufacturerModel, dgvVehicleManufacturers);
        }
    }
}
