using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using OpenRoads.Model;
using OpenRoads.Model.Requests;

namespace OpenRoads.WinUI.Client
{
    public partial class frmAddUpdateClient : Form
    {
        private readonly APIService _clientService = new APIService("Client");
        private readonly APIService _personService = new APIService("Person");
        private readonly APIService _loginDataService = new APIService("LoginData");
        private readonly APIService _countryService = new APIService("Country");

        private int? _clientId;
        private int? _personId;
        private int? _loginDataId;
        private int? _countryId;

        public frmAddUpdateClient(int clientId = 0, int personId = 0, int loginDataId = 0, int countryId = 0)
        {
            InitializeComponent();
            _clientId = clientId;
            _personId = personId;
            _loginDataId = loginDataId;
            _countryId = countryId;
        }




        private async void frmAddUpdateClient_Load(object sender, EventArgs e)
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbCountry, _countryService, "CountryModel");

            if (_clientId.HasValue && _personId.HasValue && _loginDataId.HasValue && _countryId.HasValue)
            {
                var personObj = await _personService.GetById<PersonModel>(_personId);
                var loginDataObj = await _loginDataService.GetById<LoginDataModel>(_loginDataId);

                txtCity.Text = personObj.City;
                txtPhone.Text = personObj.PhoneNumber;
                txtAddress.Text = personObj.Address;
                txtFirstName.Text = personObj.FirstName;
                txtLastName.Text = personObj.LastName;
                txtEmail.Text = personObj.Email;
                cmbCountry.SelectedValue = personObj.CountryId;
                dtpDateOfBirth.Value = personObj.DateOfBirth;

                txtUsername.Text = loginDataObj.Username;
                txtPassword.Text = "";
            }

        }


        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var cId = cmbCountry.SelectedValue;
                int.TryParse(cId.ToString(), out int countryId);

                var request = new ClientUpdateRequest
                {
                    CountryId = countryId,
                    CleasPassword = txtPassword.Text,
                    Active = true,
                    Address = txtAddress.Text,
                    City = txtCity.Text,
                    DateOfBirth = dtpDateOfBirth.Value,
                    Email = txtEmail.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    PhoneNumber = txtPhone.Text,
                    Username = txtUsername.Text
                };

                ClientModel clientModel = null;

                if (_clientId.HasValue && _countryId.HasValue && _personId.HasValue && _loginDataId.HasValue)
                    clientModel = await _clientService.Update<ClientModel>(_clientId.Value, request);


                if (clientModel != null)
                {
                    MessageBox.Show("Success!");
                    if (Form.ActiveForm != null)
                        Form.ActiveForm.Close();
                }
            }
        }



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

        
    }
}
