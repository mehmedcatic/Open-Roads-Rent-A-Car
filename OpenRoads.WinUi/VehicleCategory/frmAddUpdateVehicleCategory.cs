using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenRoads.WinUI.WFHelpers;

namespace OpenRoads.WinUI.VehicleCategory
{
    public partial class frmAddUpdateVehicleCategory : Form
    {
        private readonly APIService _service = new APIService("VehicleCategory");

        private int? _id = null;

        public frmAddUpdateVehicleCategory(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }




        private void frmAddUpdateVehicleCategory_Load(object sender, EventArgs e)
        {
            VFormBaseMethods.AddOrUpdateModel(_id, txtName, WinFormModelTypesList.ModelTypes.VehicleCategoryModel);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                VFormBaseMethods.BtnSubmitModel(_id, txtName, WinFormModelTypesList.ModelTypes.VehicleCategoryModel);
            }
        }


        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtName, e, errorProvider1);
        }
    }
}
