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

namespace OpenRoads.WinUI.Reservation
{
    public partial class frmReservation : Form
    {
        private readonly APIService _reservationService = new APIService("Reservation");
        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _insuranceService = new APIService("Insurance");
        private readonly APIService _clientService = new APIService("Client");
        private readonly APIService _personService = new APIService("Person");
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");
        private readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");

        
        public frmReservation()
        {
            InitializeComponent();
        }




        private class ReservationToDisplay
        {
            public int ReservationId { get; set; }
            public int ClientId { get; set; }
            public int VehicleId { get; set; }
            public int InsuranceId { get; set; }

            public string ClientName { get; set; }
            public string VehicleModelManufacturer { get; set; }
            public float ReservationPrice { get; set; }
            public string InsuranceName { get; set; }
            public bool Active { get; set; }

        }

        private List<ReservationToDisplay> GenerateResult(List<ReservationModel> reservations,
            List<OpenRoads.Model.VehicleModel> vehicles, List<InsuranceModel> insurances, List<ClientModel> clients,
            List<PersonModel> persons, List<VehicleModelModel> models, List<VehicleManufacturerModel> manufacturers)
        {
            List<ReservationToDisplay> result = new List<ReservationToDisplay>();
            foreach (var reservation in reservations)
            {
                ReservationToDisplay newReservation = new ReservationToDisplay();
                newReservation.ReservationId = reservation.ReservationId;
                newReservation.ClientId = reservation.ClientId;
                newReservation.VehicleId = reservation.VehicleId;
                newReservation.InsuranceId = reservation.InsuranceId;
                newReservation.Active = reservation.Active;
                newReservation.ReservationPrice = reservation.Price;

                foreach (var insurance in insurances)
                {
                    if (reservation.InsuranceId == insurance.InsuranceId)
                    {
                        newReservation.InsuranceName = insurance.Name;
                        break;
                    }
                }

                foreach (var client in clients)
                {
                    if (reservation.ClientId == client.ClientId)
                    {
                        foreach (var person in persons)
                        {
                            if (client.PersonId == person.PersonId)
                            {
                                newReservation.ClientName = person.FirstName + " " + person.LastName;
                                break;
                            }
                        }

                        break;
                    }
                }

                foreach (var vehicle in vehicles)
                {
                    if (reservation.VehicleId == vehicle.VehicleId)
                    {
                        foreach (var model in models)
                        {
                            if (vehicle.VehicleModelId == model.VehicleModelId)
                            {
                                foreach (var manufacturer in manufacturers)
                                {
                                    if (model.VehicleManufacturerId == manufacturer.VehicleManufacturerId)
                                    {
                                        newReservation.VehicleModelManufacturer = manufacturer.Name + " " + model.Name;
                                        break;
                                    }
                                }

                                break;
                            }
                        }

                        break;
                    }
                }

                result.Add(newReservation);
            }

            return result;
        }

        private async Task LoadReservations(int vehicleId = 0, int insuranceId = 0)
        {
            var vehicleList = await _vehicleService.Get<List<OpenRoads.Model.VehicleModel>>(null);
            var insuranceList = await _insuranceService.Get<List<InsuranceModel>>(null);
            var clientList = await _clientService.Get<List<ClientModel>>(null);
            var personList = await _personService.Get<List<PersonModel>>(null);
            var modelList = await _vehicleModelService.Get<List<VehicleModelModel>>(null);
            var manufacturerList = await _vehicleManufacturerService.Get<List<VehicleManufacturerModel>>(null);

            if (vehicleId != 0 || insuranceId != 0)
            {
                var request = new ReservationSearchRequest();
                if (vehicleId != 0)
                    request.VehicleId = vehicleId;
                if (insuranceId != 0)
                    request.InsuranceId = insuranceId;

                var reservations = await _reservationService.Get<List<ReservationModel>>(request);

                var result = GenerateResult(reservations, vehicleList, insuranceList, clientList, personList, modelList,
                    manufacturerList);

                dgvReservations.AutoGenerateColumns = false;
                dgvReservations.DataSource = result;
            }
            else
            {
                var reservations = await _reservationService.Get<List<ReservationModel>>(null);

                var result = GenerateResult(reservations, vehicleList, insuranceList, clientList, personList, modelList,
                    manufacturerList);

                dgvReservations.AutoGenerateColumns = false;
                dgvReservations.DataSource = result;
            }
        }

        private async void frmReservation_Load(object sender, EventArgs e)
        {
            await VFormBaseMethods.LoadAssetToComboBox(cmbVehicle, _vehicleService,
                WinFormModelTypesList.ModelTypes.VehicleModel.ToString());
            await VFormBaseMethods.LoadAssetToComboBox(cmbInsurance, _insuranceService,
                WinFormModelTypesList.ModelTypes.InsuranceModel.ToString());

            await LoadReservations();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var vId = cmbVehicle.SelectedValue;
            var iId = cmbInsurance.SelectedValue;

            int.TryParse(vId.ToString(), out int vehicleId);
            int.TryParse(iId.ToString(), out int insuranceId);

            if (vehicleId != 0 && insuranceId != 0)
                await LoadReservations(vehicleId, insuranceId);
            if (vehicleId != 0 && insuranceId == 0)
                await LoadReservations(vehicleId, 0);
            if (vehicleId == 0 && insuranceId != 0)
                await LoadReservations(0, insuranceId);
            if(vehicleId == 0 && insuranceId == 0)
                await LoadReservations();
        }

        private void dgvReservations_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var reservationID = dgvReservations.SelectedRows[0].Cells[0].Value;
            var clientID = dgvReservations.SelectedRows[0].Cells[1].Value;
            var vehicleID = dgvReservations.SelectedRows[0].Cells[2].Value;
            var insuranceID = dgvReservations.SelectedRows[0].Cells[3].Value;

            frmReservationMoreData frm = new frmReservationMoreData(int.Parse(reservationID.ToString()),
                int.Parse(clientID.ToString()), int.Parse(vehicleID.ToString()),
                int.Parse(insuranceID.ToString()));
            frm.Show();
        }
    }
}
