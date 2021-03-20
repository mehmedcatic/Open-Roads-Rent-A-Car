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

namespace OpenRoads.WinUI.Rating
{
    public partial class frmRating : Form
    {
        private readonly APIService _ratingService = new APIService("Rating");
        private readonly APIService _clientService = new APIService("Client");
        private readonly APIService _personService = new APIService("Person");
        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");

        public frmRating()
        {
            InitializeComponent();
        }




        private class ClientsToDisplay
        {
            public int ClientId { get; set; }
            public string ClientName { get; set; }
        }

        private class VehiclesToDisplay
        {
            public int VehicleId { get; set; }
            public string VehicleName { get; set; }
        }

        private class RatingsToDisplay
        {
            public int RatingId { get; set; }
            public int RatingInt { get; set; }
            public DateTime CreationDate { get; set; }
            public string Comment { get; set; }
            public int ClientId { get; set; }
            public int VehicleId { get; set; }
            public string ClientName { get; set; }
            public string VehicleName { get; set; }
        }

     
        private async Task LoadVehicles()
        {
            var vehicles = await _vehicleService.Get<List<OpenRoads.Model.VehicleModel>>(null);
            var vehicleModels = await _vehicleModelService.Get<List<VehicleModelModel>>(null);
            var vehicleResultList = generateVehiclesToDisplay(vehicleModels, vehicles);

            vehicleResultList.Insert(0, new VehiclesToDisplay());
            cmbVehicle.DisplayMember = "VehicleName";
            cmbVehicle.ValueMember = "VehicleId";
            cmbVehicle.DataSource = vehicleResultList;
        }

        private List<ClientsToDisplay> generateClientsToDisplay(List<PersonModel> persons, 
            List<ClientModel> clients = null, ClientModel client = null)
        {
            var clientsResultList = new List<ClientsToDisplay>();
            
                foreach (var x in clients)
                {
                        foreach (var y in persons)
                        {
                            if (x.PersonId == y.PersonId)
                            {
                                clientsResultList.Add(new ClientsToDisplay
                                {
                                    ClientName = y.FirstName + " " + y.LastName,
                                    ClientId = x.ClientId
                                });
                                break;
                            }
                        }
                }
                
            return clientsResultList;
        }

        private List<VehiclesToDisplay> generateVehiclesToDisplay(List<VehicleModelModel> vehicleModels, 
            List<OpenRoads.Model.VehicleModel> vehicles = null, OpenRoads.Model.VehicleModel vehicle = null)
        {
            var vehiclesList = new List<VehiclesToDisplay>();
            if (vehicle != null)
            {
                foreach (var x in vehicles)
                {
                    if (x.VehicleId == vehicle.VehicleId)
                    {
                        foreach (var y in vehicleModels)
                        {
                            if (x.VehicleModelId == y.VehicleModelId)
                            {
                                vehiclesList.Add(new VehiclesToDisplay
                                {
                                    VehicleName = y.Name,
                                    VehicleId = x.VehicleId
                                });
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var x in vehicles)
                {
                        foreach (var y in vehicleModels)
                        {
                            if (x.VehicleModelId == y.VehicleModelId)
                            {
                                vehiclesList.Add(new VehiclesToDisplay
                                {
                                    VehicleName = y.Name,
                                    VehicleId = x.VehicleId
                                });
                                break;
                            }
                        }
                }
            }

            return vehiclesList;
        }

        private List<RatingsToDisplay> GenerateResult(List<VehiclesToDisplay> vehiclesList,
            List<ClientsToDisplay> clientsList, List<RatingModel> ratings)
        {
            List<RatingsToDisplay> ratingsList = new List<RatingsToDisplay>();


            foreach (var rating in ratings)
            {
                RatingsToDisplay newRating = new RatingsToDisplay();

                foreach (var vehicle in vehiclesList)
                {
                    if (rating.VehicleId == vehicle.VehicleId)
                    {

                        foreach (var client in clientsList)
                        {
                            if (rating.ClientId == client.ClientId)
                            {
                                newRating.ClientId = client.ClientId;
                                newRating.ClientName = client.ClientName;
                                break;
                            }
                        }

                        newRating.VehicleId = vehicle.VehicleId;
                        newRating.VehicleName = vehicle.VehicleName;
                        newRating.Comment = rating.Comment;
                        newRating.CreationDate = rating.CreationDate;
                        newRating.RatingInt = rating.RatingInt;
                        newRating.RatingId = rating.RatingId;

                        ratingsList.Add(newRating);
                    }
                }
            }
            dgvRatings.AutoGenerateColumns = false; 
            dgvRatings.DataSource = ratingsList;

            return ratingsList;
        }

        private async Task LoadRatings(int vehicleId = 0)
        {
            var ratings = await _ratingService.Get<List<RatingModel>>(null);
            var vehicleModels = await _vehicleModelService.Get<List<VehicleModelModel>>(null);
            var persons = await _personService.Get<List<PersonModel>>(null);
            var vehicles = await _vehicleService.Get<List<OpenRoads.Model.VehicleModel>>(null);
            var clients = await _clientService.Get<List<ClientModel>>(null);

            if (vehicleId != 0)
            {

                OpenRoads.Model.VehicleModel vehicle = await _vehicleService.GetById<OpenRoads.Model.VehicleModel>(vehicleId);
               
                var clientsList = generateClientsToDisplay(persons, clients);
                var vehiclesList = generateVehiclesToDisplay(vehicleModels, vehicles, vehicle);

                var ratingsList = GenerateResult(vehiclesList, clientsList, ratings);

                dgvRatings.AutoGenerateColumns = false;
                dgvRatings.DataSource = ratingsList;
            }

            else
            {
                var vehiclesList = generateVehiclesToDisplay(vehicleModels, vehicles, null);
                var clientsList = generateClientsToDisplay(persons, clients, null);

                var ratingsList = GenerateResult(vehiclesList, clientsList, ratings);

                dgvRatings.AutoGenerateColumns = false;
                dgvRatings.DataSource = ratingsList;
            }

            
        }

        private async void frmRating_Load(object sender, EventArgs e)
        {
            await LoadVehicles();
            await LoadRatings();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var vehicleId = cmbVehicle.SelectedValue;
                if (int.TryParse(vehicleId.ToString(), out int Vid))
                {
                    await LoadRatings(Vid);
                }
                else
                {
                    await LoadRatings();
                }
            
        }
    }
}
