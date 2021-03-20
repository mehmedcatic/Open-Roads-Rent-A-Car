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

namespace OpenRoads.WinUI.EmployeeRoles
{
    public partial class frmAddUpdateEmployeeRoles : Form
    {
        private readonly APIService _employeeRolesService = new APIService("EmployeeRoles");

        private int? _employeeRolesID = null;

        public frmAddUpdateEmployeeRoles(int employeeRoles = 0)
        {
            InitializeComponent();
            _employeeRolesID = employeeRoles;
        }






        private async void frmAddUpdateEmployeeRoles_Load(object sender, EventArgs e)
        {
            if (_employeeRolesID != 0)
            {
                var emplRole = await _employeeRolesService.GetById<EmployeeRolesModel>(_employeeRolesID);

                txtDescription.Text = emplRole.Description;
                txtName.Text = emplRole.Name;
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var request = new EmployeeRolesInsertUpdateRequest
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text
                };

                EmployeeRolesModel model = null;
                if (_employeeRolesID != 0)
                {
                    model = await _employeeRolesService.Update<EmployeeRolesModel>(int.Parse(_employeeRolesID.ToString())
                        , request);
                }
                else
                {
                    model = await _employeeRolesService.Insert<EmployeeRolesModel>(request);
                }

                if (model != null)
                {
                    MessageBox.Show("Success!");
                    if (Form.ActiveForm != null)
                        Form.ActiveForm.Close();
                }
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtDescription, e, errorProvider1, false, false, false, false, true);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtName, e, errorProvider1);
        }

    }
}
