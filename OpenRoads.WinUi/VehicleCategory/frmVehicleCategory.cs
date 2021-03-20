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

namespace OpenRoads.WinUI.VehicleCategory
{
    public partial class frmVehicleCategory : Form
    {
        private readonly APIService _service = new APIService("VehicleCategory");

        public frmVehicleCategory()
        {
            InitializeComponent();
        }


        private async void frmVehicleCategory_Load(object sender, EventArgs e)
        {
            var objects = await _service.Get<List<VehicleCategoryModel>>(null);

            VFormBaseMethods.baseFormForVehicleReferenceModelsLoad(
                WinFormModelTypesList.ModelTypes.VehicleCategoryModel, dgvVehicleCategories, objects, 
                new List<VehicleFuelTypeModel>(), new List<VehicleTypeModel>(), new List<VehicleManufacturerModel>(),
                new List<VehicleTransmissionTypeModel>());
        }

        private void dgvVehicleCategories_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VFormBaseMethods.MouseDoubleClick(WinFormModelTypesList.ModelTypes.VehicleCategoryModel, dgvVehicleCategories);
        }
    }
}
