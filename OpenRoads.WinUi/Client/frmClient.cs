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

namespace OpenRoads.WinUI.Client
{
    public partial class frmClient : Form
    {
        private readonly APIService _countryService = new APIService("Country");
        private readonly APIService _personService = new APIService("Person");
        private readonly APIService _loginDataService = new APIService("LoginData");
        private readonly APIService _clientService = new APIService("Client");


        public frmClient()
        {
            InitializeComponent();
        }






        private async void frmClient_Load(object sender, EventArgs e)
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbCountry, new APIService("Country"), "CountryModel");
            await LoadClients();
        }

        private class ClientsToDisplay
        {
            public int ClientId { get; set; }
            public DateTime RegistrationDate { get; set; }
            public int PersonId { get; set; }
            public string FullName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Username { get; set; }
            public int LoginDataId { get; set; }
            public int CountryId { get; set; }
            public string CountryName { get; set; }
        }

        private List<ClientsToDisplay> GenerateResult(List<ClientModel> clients, List<PersonModel> persons,
            List<LoginDataModel> loginModels, List<CountryModel> countries)
        {
            List<ClientsToDisplay> result = new List<ClientsToDisplay>();

            foreach (var x in clients)
            {
                ClientsToDisplay newClient = new ClientsToDisplay();
                foreach (var y in persons)
                {
                    if (x.PersonId == y.PersonId)
                    {
                        newClient.ClientId = x.ClientId;
                        newClient.DateOfBirth = y.DateOfBirth;
                        newClient.Email = y.Email;
                        newClient.FullName = y.FirstName + " " + y.LastName;
                        newClient.PhoneNumber = y.PhoneNumber;
                        newClient.CountryId = y.CountryId;
                        newClient.RegistrationDate = x.RegistrationDate;
                        newClient.PersonId = x.PersonId;

                        foreach (var z in loginModels)
                        {
                            if (y.LoginDataId == z.LoginDataId)
                            {
                                newClient.Username = z.Username;
                                newClient.LoginDataId = z.LoginDataId;
                                break;
                            }
                        }

                        foreach (var w in countries)
                        {
                            if (y.CountryId == w.CountryId)
                            {
                                newClient.CountryName = w.Name;
                                break;
                            }
                        }
                    }
                }

                result.Add(newClient);
            }

            return result;
        }

        private async Task LoadClients(int countryId = 0)
        {
            var personList = await _personService.Get<List<PersonModel>>(null);
            var loginDataList = await _loginDataService.Get<List<LoginDataModel>>(null);
            var countriesList = await _countryService.Get<List<CountryModel>>(null);

            if (countryId != 0)
            {
                var request = new ClientSearchRequest
                {
                    CountryId = countryId
                };
                

                var clientsList = await _clientService.Get<List<ClientModel>>(request);

                var result = GenerateResult(clientsList, personList, loginDataList, countriesList);

                dgvClients.AutoGenerateColumns = false;
                dgvClients.DataSource = result;
            }
            else
            {
                var clientsList = await _clientService.Get<List<ClientModel>>(null);

                var result = GenerateResult(clientsList, personList, loginDataList, countriesList);

                dgvClients.AutoGenerateColumns = false;
                dgvClients.DataSource = result;
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var countryId = cmbCountry.SelectedValue;
            if (int.TryParse(countryId.ToString(), out int Cid))
                await LoadClients(Cid);
            else
            {
                await LoadClients();
            }
        }

        private void dgvClients_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var clientId = dgvClients.SelectedRows[0].Cells[0].Value;
            var personId = dgvClients.SelectedRows[0].Cells[1].Value;
            var loginDataId = dgvClients.SelectedRows[0].Cells[2].Value;
            var countryId = dgvClients.SelectedRows[0].Cells[3].Value;

            frmAddUpdateClient frm = new frmAddUpdateClient(int.Parse(clientId.ToString()), 
                int.Parse(personId.ToString()), int.Parse(loginDataId.ToString()), int.Parse(countryId.ToString()));
            frm.Show();
        }
    }
}
