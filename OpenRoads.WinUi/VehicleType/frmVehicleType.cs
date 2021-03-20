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

namespace OpenRoads.WinUI.VehicleType
{
    public partial class frmVehicleType : Form
    {
        private readonly APIService _service = new APIService("VehicleType");

        public frmVehicleType()
        {
            InitializeComponent();
        }

        private async void frmVehicleType_Load(object sender, EventArgs e)
        {
            var objects = await _service.Get<List<VehicleTypeModel>>(null);

            VFormBaseMethods.baseFormForVehicleReferenceModelsLoad(
                WinFormModelTypesList.ModelTypes.VehicleTypeModel, dgvVehicleType, new List<VehicleCategoryModel>(),
                new List<VehicleFuelTypeModel>(), objects, new List<VehicleManufacturerModel>(),
                new List<VehicleTransmissionTypeModel>());
        }

        private void dgvVehicleTransmissionTypes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VFormBaseMethods.MouseDoubleClick(WinFormModelTypesList.ModelTypes.VehicleTypeModel, dgvVehicleType);
        }
    }
}
