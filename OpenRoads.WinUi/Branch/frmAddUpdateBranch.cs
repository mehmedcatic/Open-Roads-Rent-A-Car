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

namespace OpenRoads.WinUI.Branch
{
    public partial class frmAddUpdateBranch : Form
    {
        private readonly APIService _branchService = new APIService("Branch");
        private readonly APIService _countryService = new APIService("Country");

        private int? _branchId, _countryId;

        public frmAddUpdateBranch(int? branchId = null, int? countryId = null)
        {
            InitializeComponent();
            _branchId = branchId;
            _countryId = countryId;
        }





        private async void frmAddUpdateBranch_Load(object sender, EventArgs e)
        {
            await LoadCountries();
            if (_branchId.HasValue || _countryId.HasValue)
            {
                var countryUpdate = await _countryService.GetById<CountryModel>(_countryId);
                var branchUpdate = await _branchService.GetById<BranchModel>(_branchId);

                txtCity.Text = branchUpdate.City;
                txtPhone.Text = branchUpdate.PhoneNumber;
                txtAddress.Text = branchUpdate.Address;
                txtDescription.Text = branchUpdate.Description;
                txtZipCode.Text = branchUpdate.ZIPCode;
                txtWorkingTo.Text = branchUpdate.WorkingHoursTo.ToString();
                txtWorkingFrom.Text = branchUpdate.WorkingHoursFrom.ToString();
                txtName.Text = branchUpdate.FullName;
                //cbActive.Checked = branchUpdate.Active;
                cmbCountry.SelectedValue = countryUpdate.CountryId;
            }
        }

        

        private async Task LoadCountries()
        {
            var result = await _countryService.Get<List<CountryModel>>(null);
            result.Insert(0, new CountryModel());
            cmbCountry.DisplayMember = "Name";
            cmbCountry.ValueMember = "CountryId";
            cmbCountry.DataSource = result;
        }


        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var cId = cmbCountry.SelectedValue;
                int.TryParse(cId.ToString(), out int countryId);

                var request = new BranchInsertUpdateRequest
                {
                    CountryId = countryId,
                    City = txtCity.Text,
                    Active = true,
                    PhoneNumber = txtPhone.Text,
                    Description = txtDescription.Text,
                    Address = txtAddress.Text,
                    FullName = txtName.Text,
                    WorkingHoursFrom = int.Parse(txtWorkingFrom.Text),
                    WorkingHoursTo = int.Parse(txtWorkingTo.Text),
                    ZIPCode = txtZipCode.Text
                };

                BranchModel obj = null;
                if (_branchId.HasValue)
                {
                    obj = await _branchService.Update<BranchModel>(int.Parse(_branchId.ToString()), request);
                }
                else
                {
                    obj = await _branchService.Insert<BranchModel>(request);
                }

                if (obj != null)
                {
                    MessageBox.Show("Success!");
                    if (Form.ActiveForm != null)
                        Form.ActiveForm.Close();
                }
            }
        }


        private void txtName_Validating(object sender, CancelEventArgs e)
        {
             ValidateWinFormElements.ValidateTextBox(txtName, e, errorProvider1);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtPhone, e, errorProvider1);
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtAddress, e, errorProvider1);
        }

        private void txtZipCode_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtZipCode, e, errorProvider1, true);
        }

        private void cmbCountry_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateComboBox(cmbCountry, e, errorProvider1);
        }

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtCity, e, errorProvider1);
        }

        private void txtWorkingFrom_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtWorkingFrom, e, errorProvider1, true, true);
        }

        private void txtWorkingTo_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtWorkingTo, e, errorProvider1, true, true);
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtDescription, e, errorProvider1, false, false, false, false, true);
        }

    }
}
