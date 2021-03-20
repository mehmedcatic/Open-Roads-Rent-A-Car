using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenRoads.WinUI;
using OpenRoads.WinUI.WFHelpers;

namespace OpenRoads.WinUI.VehicleTransmissionType
{
    public partial class frmAddUpdateVehicleTransmissionType : Form
    {
        private readonly APIService _service = new APIService("VehicleTransmissionType");

        private int? _id = null;

        public frmAddUpdateVehicleTransmissionType(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }


        private void frmAddUpdateVehicleTransmissionType_Load(object sender, EventArgs e)
        {
            VFormBaseMethods.AddOrUpdateModel(_id, txtName, WinFormModelTypesList.ModelTypes.VehicleTransmissionTypeModel);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                VFormBaseMethods.BtnSubmitModel(_id, txtName, WinFormModelTypesList.ModelTypes.VehicleTransmissionTypeModel);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtName, e, errorProvider1);
        }
    }
}
