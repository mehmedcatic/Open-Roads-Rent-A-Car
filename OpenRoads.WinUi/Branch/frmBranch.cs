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
using OpenRoads.WinUI.WFHelpers;

namespace OpenRoads.WinUI.Branch
{
    public partial class frmBranch : Form
    {
        private readonly APIService _branchService = new APIService("Branch");
        private readonly APIService _countryService = new APIService("Country");


        public frmBranch()
        {
            InitializeComponent();
        }




        private class BranchToDisplay
        {
            public int BranchId { get; set; }
            public string FullName { get; set; }
            public string City { get; set; }
            //public string Address { get; set; }
            //public string ZIPCode { get; set; }
            public string PhoneNumber { get; set; }
            //public int WorkingHoursFrom { get; set; }
            //public int WorkingHoursTo { get; set; }
            public string Description { get; set; }
            public bool Active { get; set; }
            public int CountryId { get; set; }
            public string CountryName { get; set; }
        }

        private async Task LoadCountries()
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbCountry, _countryService, "CountryModel");
        }

        private List<BranchToDisplay> GenerateResult(List<BranchModel> branches, List<CountryModel> countries)
        {
            List<BranchToDisplay> branchesToDisplay = new List<BranchToDisplay>();
            foreach (var x in branches)
            {
                foreach (var y in countries)
                {
                    if (x.CountryId == y.CountryId)
                    {
                        branchesToDisplay.Add(new BranchToDisplay
                        {
                            CountryId = y.CountryId,
                            City = x.City,
                            PhoneNumber = x.PhoneNumber,
                            Active = x.Active,
                            FullName = x.FullName,
                            BranchId = x.BranchId,
                            CountryName = y.Name,
                            Description = x.Description
                        });
                        break;
                    }
                }
            }

            return branchesToDisplay;
        }

        private async Task LoadBranches(int countryId = 0) 
        {
            var countryList = await _countryService.Get<List<CountryModel>>(null);

            if (countryId != 0 )
            {
                var request = new BranchSearchRequest
                {
                    CountryId = countryId
                };

                var branchesList = await _branchService.Get<List<BranchModel>>(request);

                var result = GenerateResult(branchesList, countryList);

                dgvBranch.AutoGenerateColumns = false;
                dgvBranch.DataSource = result;
            }
            else
            {
                var branchesList = await _branchService.Get<List<BranchModel>>(null);

                var result = GenerateResult(branchesList, countryList);

                dgvBranch.AutoGenerateColumns = false;
                dgvBranch.DataSource = result;
            }
        }

        private async void frmBranch_Load(object sender, EventArgs e)
        {
            await LoadCountries();
            await LoadBranches();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var countryId = cmbCountry.SelectedValue;
            if (int.TryParse(countryId.ToString(), out int cId))
            {
                await LoadBranches(cId);
            }
            else
                await LoadBranches();
        }

        private void dgvBranch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var branchID = dgvBranch.SelectedRows[0].Cells[0].Value;
            var countryID = dgvBranch.SelectedRows[0].Cells[1].Value;

            frmAddUpdateBranch frm = new frmAddUpdateBranch(int.Parse(branchID.ToString()), 
                int.Parse(countryID.ToString()));
            frm.Show();
        }

        private async void dgvBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = await VFormBaseMethods.DeleteContentOnCellClick<BranchModel>(dgvBranch, e, 
                WinFormModelTypesList.ModelTypes.BranchModel.ToString());
            if (result != null)
                await LoadBranches();
        }
    }
}
