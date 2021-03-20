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

namespace OpenRoads.WinUI.VehicleFuelType
{
    public partial class frmVehicleFuelType : Form
    {
        private readonly APIService _service = new APIService("VehicleFuelType");

        public frmVehicleFuelType()
        {
            InitializeComponent();
        }

        private async void frmVehicleFuelType_Load(object sender, EventArgs e)
        {
            var objects = await _service.Get<List<VehicleFuelTypeModel>>(null);

            VFormBaseMethods.baseFormForVehicleReferenceModelsLoad(
                WinFormModelTypesList.ModelTypes.VehicleFuelTypeModel, dgvVehicleFuelType, new List<VehicleCategoryModel>(),
                objects, new List<VehicleTypeModel>(), new List<VehicleManufacturerModel>(),
                new List<VehicleTransmissionTypeModel>());
        }

        private void dgvVehicleFuelType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VFormBaseMethods.MouseDoubleClick(WinFormModelTypesList.ModelTypes.VehicleFuelTypeModel, dgvVehicleFuelType);
        }
    }
}
