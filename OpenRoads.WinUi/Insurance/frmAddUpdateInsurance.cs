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

namespace OpenRoads.WinUI.Insurance
{
    public partial class frmAddUpdateInsurance : Form
    {
        private  readonly APIService _insuranceService = new APIService("Insurance");

        private int? _insuranceId = null;

        public frmAddUpdateInsurance(int? insuranceId = null)
        {
            InitializeComponent();
            _insuranceId = insuranceId;
        }



        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var request = new InsuranceInsertUpdateRequest
                {
                    Name = txtName.Text,
                    Price = float.Parse(txtPrice.Text)
                };

                InsuranceModel entity = null;

                if (_insuranceId.HasValue)
                {
                    entity = await _insuranceService.Update<InsuranceModel>(int.Parse(_insuranceId.ToString()), request);
                }
                else
                {
                    entity = await _insuranceService.Insert<InsuranceModel>(request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Success!");
                    if (Form.ActiveForm != null)
                        Form.ActiveForm.Close();
                }
            }
        }

       
        private async void frmAddUpdateInsurance_Load(object sender, EventArgs e)
        {
            if (_insuranceId.HasValue)
            {
                var obj = await _insuranceService.GetById<InsuranceModel>(_insuranceId);
                txtName.Text = obj.Name;
                txtPrice.Text = obj.Price.ToString();
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            ValidateWinFormElements.ValidateTextBox(txtName, e, errorProvider1);
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
           ValidateWinFormElements.ValidateTextBox(txtPrice, e, errorProvider1, true);
        }

    }
}
