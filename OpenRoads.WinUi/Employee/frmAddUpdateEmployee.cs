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

namespace OpenRoads.WinUI.Employee
{
    public partial class frmAddUpdateEmployee : Form
    {
        APIService _employeeService = new APIService("Employee");
        APIService _employeeRoleService = new APIService("EmployeeRoles");
        APIService _employeeEmployeeRolesService = new APIService("EmployeeEmployeeRoles");
        APIService _logindataService = new APIService("LoginData");
        APIService _countryService = new APIService("Country");
        APIService _branchService = new APIService("Branch");
        APIService _personService = new APIService("Person");

        private int? _employeeID = null;
        private int? _branchID = null;
        private int? _personID = null;

        public frmAddUpdateEmployee(int? employeeID = null, int? branchID = null, int? personID = null)
        {
            InitializeComponent();
            _employeeID = employeeID;
            _branchID = branchID;
            _personID = personID;
        }




        private async Task LoadBranch()
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbBranch, _branchService, "BranchModel");
        }
        private async Task LoadCountry()
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbCountry, _countryService, "CountryModel");
        }
        private async Task LoadRoles()
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbEmployeeRole, _employeeRoleService, "EmployeeRolesModel");
        }
        private async void frmAddUpdateEmployee_Load(object sender, EventArgs e)
        {
            await LoadBranch();
            await LoadCountry();
            await LoadRoles();

            if (_employeeID.HasValue && _branchID.HasValue && _personID.HasValue)
            {
                var employeeObj = await _employeeService.GetById<EmployeeModel>(_employeeID);
                var personObj = await _personService.GetById<PersonModel>(_personID);
                var loginDataObj = await _logindataService.GetById<LoginDataModel>(personObj.LoginDataId);
                var employeeEmplRolesObj =
                    await _employeeEmployeeRolesService.GetById<EmployeeEmployeeRolesModel>(
                        int.Parse(_employeeID.ToString()));


                //PERSON ATTR
                txtLastName.Text = personObj.LastName;
                txtAddress.Text = personObj.Address;
                txtEmail.Text = personObj.Email;
                txtPhone.Text = personObj.PhoneNumber;
                txtCity.Text = personObj.City;
                txtFirstName.Text = personObj.FirstName;
                cmbCountry.SelectedValue = personObj.CountryId;
                dtpDateOfBirth.Value = personObj.DateOfBirth;

                //EMPLOYEE ATTR
                txtEmployeeCode.Text = employeeObj.EmployeeCode;
                txtJobDesc.Text = employeeObj.JobDescription;
                cmbEmployeeRole.SelectedValue = 0;
                cmbBranch.SelectedValue = employeeObj.BranchId;
                dtpHireDate.Value = employeeObj.HireDate;

                //LOGINDATA ATTR
                txtUsername.Text = loginDataObj.Username;
                txtPassword.Text = "";

                cmbEmployeeRole.SelectedValue = employeeEmplRolesObj.EmployeeRolesId;
            }
        }

       

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var brId = cmbBranch.SelectedValue;
                int.TryParse(brId.ToString(), out int branchId);

                var cId = cmbCountry.SelectedValue;
                int.TryParse(cId.ToString(), out int countryId);

                var eId = cmbEmployeeRole.SelectedValue;
                int.TryParse(eId.ToString(), out int roleId);

                var request = new EmployeeInsertUpdateRequest
                {
                    BranchId = branchId,
                    CountryId = countryId,
                    Active = true,
                    Address = txtAddress.Text,
                    City = txtCity.Text,
                    DateOfBirth = dtpDateOfBirth.Value,
                    Email = txtEmail.Text,
                    EmployeeCode = txtEmployeeCode.Text,
                    FirstName = txtFirstName.Text,
                    HireDate = dtpHireDate.Value,
                    JobDescription = txtJobDesc.Text,
                    LastName = txtLastName.Text,
                    PhoneNumber = txtPhone.Text,
                    Username = txtUsername.Text,
                    CleasPassword = txtPassword.Text,
                    EmployeeRoleId = roleId
                };

                EmployeeModel employee = null;

                if (_employeeID.HasValue && _branchID.HasValue && _personID.HasValue)
                    employee = await _employeeService.Update<EmployeeModel>(_employeeID.Value, request);

                else
                {
                    employee = await _employeeService.Insert<EmployeeModel>(request);
                }

                if (employee != null)
                {
                    MessageBox.Show("Success!");
                    if(Form.ActiveForm != null) 
                        Form.ActiveForm.Close();
                }
            }
        }


        //VALIDATION
        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
           ValidateWinFormElements.ValidateTextBox(txtFirstName, e, errorProvider1);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtLastName, e, errorProvider1);
        }

        private void dtpDateOfBirth_Validating(object sender, CancelEventArgs e)
        {
           ValidateWinFormElements.ValidateDateTimePicker(dtpDateOfBirth, e, errorProvider1, true);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtEmail, e, errorProvider1, false, false, false, true);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtPhone, e, errorProvider1);
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtAddress, e, errorProvider1);
        }

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtCity, e, errorProvider1);
        }

        private void cmbCountry_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateComboBox(cmbCountry, e, errorProvider1);
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtUsername, e, errorProvider1);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtPassword, e, errorProvider1, false, false, true);
        }

        private void txtEmployeeCode_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtEmployeeCode, e, errorProvider1);
        }

        private void txtJobDesc_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtJobDesc, e, errorProvider1, false, false, false, false, true);
        }

        private void dateTimePicker2_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateDateTimePicker(dtpHireDate, e, errorProvider1, false, true);
        }

        private void cmbBranch_Validating(object sender, CancelEventArgs e)
        {
           ValidateWinFormElements.ValidateComboBox(cmbBranch, e, errorProvider1);
        }

    }
}
