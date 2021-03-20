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

namespace OpenRoads.WinUI.Reservation
{
    public partial class frmReservationMoreData : Form
    {
        private readonly APIService _reservationService = new APIService("Reservation");
        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _insuranceService = new APIService("Insurance");
        private readonly APIService _clientService = new APIService("Client");
        private readonly APIService _personService = new APIService("Person");
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");
        private readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");

        private int? _reservationId = null;
        private int? _clientId = null;
        private int? _vehicleId = null;
        private int? _insuranceId = null;

        public frmReservationMoreData(int? reservationId = null, int? clientId = null, int? vehicleId = null,
            int? insuranceId = null)
        {
            InitializeComponent();
            _reservationId = reservationId;
            _clientId = clientId;
            _vehicleId = vehicleId;
            _insuranceId = insuranceId;
        }

        private async void frmReservationMoreData_Load(object sender, EventArgs e)
        {
            if (_reservationId.HasValue && _clientId.HasValue && _vehicleId.HasValue && _insuranceId.HasValue)
            {
                var vehicle = await _vehicleService.GetById<OpenRoads.Model.VehicleModel>(int.Parse(_vehicleId.ToString()));
                var insurance = await _insuranceService.GetById<InsuranceModel>(int.Parse(_insuranceId.ToString()));
                var client = await _clientService.GetById<ClientModel>(int.Parse(_clientId.ToString()));
                var personList = await _personService.Get<List<PersonModel>>(null);
                var modelList = await _vehicleModelService.Get<List<VehicleModelModel>>(null);
                var manufacturerList = await _vehicleManufacturerService.Get<List<VehicleManufacturerModel>>(null);
                var reservation =
                    await _reservationService.GetById<ReservationModel>(int.Parse(_reservationId.ToString()));

                txtPrice.Text = reservation.Price.ToString();
                txtAdditionalInfo.Text = reservation.AdditionalInfo;
                dtpCreationDate.Value = reservation.CreationDate;
                dtpEndDate.Value = reservation.DateTo;
                dtpStartDate.Value = reservation.DateFrom;
                cbActive.Checked = reservation.Active;
                cbCanceled.Checked = reservation.Canceled;
                txtInsuranceName.Text = insurance.Name;


                foreach (var person in personList)
                {
                    if (client.PersonId == person.PersonId)
                    {
                        txtClientName.Text = person.FirstName + " " + person.LastName;
                        break;
                    }
                }


                foreach (var model in modelList)
                {
                    if (vehicle.VehicleModelId == model.VehicleModelId)
                    {
                        foreach (var manufacturer in manufacturerList)
                        {
                            if (model.VehicleManufacturerId == manufacturer.VehicleManufacturerId)
                            {
                                txtVehicleName.Text = manufacturer.Name + " " + model.Name;
                                break;
                            }
                        }
                        break;
                    }
                }

            }
        }
    }
}
