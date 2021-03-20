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

namespace OpenRoads.WinUI.Country
{
    public partial class frmAddCountry : Form
    {
        private readonly APIService _countryService = new APIService("Country");

        public frmAddCountry()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var request = new CountryInsertRequest
                {
                    Name = txtName.Text
                };

                CountryModel entity = null;
                entity = await _countryService.Insert<CountryModel>(request);

                if (entity != null)
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
    }
}
