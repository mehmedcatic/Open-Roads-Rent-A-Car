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

namespace OpenRoads.WinUI.Country
{
    public partial class frmCountries : Form
    {
        private readonly APIService _countryService = new APIService("Country");

        public frmCountries()
        {
            InitializeComponent();
        }

        private async void frmCountries_Load(object sender, EventArgs e)
        {
            var result = await _countryService.Get<List<CountryModel>>(null);
            dgvCountry.AutoGenerateColumns = false;
            dgvCountry.DataSource = result;
        }
    }
}
