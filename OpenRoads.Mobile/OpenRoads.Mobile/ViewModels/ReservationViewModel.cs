using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenRoads.Mobile;
using OpenRoads.Mobile.ViewModels;
using OpenRoads.Mobile.Views;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using Xamarin.Forms;

namespace OpenRoads.Mobile.ViewModels
{
    public class ReservationViewModel : BaseViewModel
    {
        private int _vehicleId;
        public DateTime _startDate { get; }
        public DateTime _endDate { get; }

        private readonly APIService _clientService = new APIService("Client");
        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");
        private readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");
        private readonly APIService _insuranceService = new APIService("Insurance");
        private readonly APIService _reservationService = new APIService("Reservation");

        public ReservationViewModel()
        {
            
        }

        //Since reservation view will be displayed only when the desired vehicle is selected, we are able to pass some parameters through constructor
        public ReservationViewModel(int vehicleId, DateTime startDate, DateTime endDate)
        {
            _vehicleId = vehicleId;
            _startDate = startDate;
            _endDate = endDate;

            InitCommand = new Command(async () => await Init());
            CreateReservationCommand = new Command(async () => await Create());
        }

        public ObservableCollection<InsuranceModel> InsuranceList { get; set; } = new ObservableCollection<InsuranceModel>();

        private ClientModel _loggedClient = null;
        public ClientModel LoggedClient
        {
            get { return _loggedClient; }
            set
            {
                SetProperty(ref _loggedClient, value);
            }
        }

        string _additionalInfo = string.Empty;
        public string AdditionalInfo
        {
            get { return _additionalInfo; }
            set { SetProperty(ref _additionalInfo, value); }
        }

        string _vehicleName = string.Empty;
        public string VehicleName
        {
            get { return _vehicleName; }
            set { SetProperty(ref _vehicleName, value); }
        }

        int _manufacturedYear;
        public int ManufacturedYear
        {
            get { return _manufacturedYear; }
            set { SetProperty(ref _manufacturedYear, value); }
        }

        string _horsePower;
        public string HorsePower
        {
            get { return _horsePower; }
            set { SetProperty(ref _horsePower, value); }
        }

        string _dailyPrice;
        public string DailyPrice
        {
            get { return _dailyPrice; }
            set { SetProperty(ref _dailyPrice, value); }
        }

        byte[] _vehiclePicture;
        public byte[] VehiclePicture
        {
            get { return _vehiclePicture; }
            set { SetProperty(ref _vehiclePicture, value); }
        }

        string _totalPrice;
        public string TotalPrice
        {
            get { return _totalPrice; }
            set { SetProperty(ref _totalPrice, value); }
        }

        string _vehicleRentalPrice;
        public string VehicleRentalPrice
        {
            get { return _vehicleRentalPrice; }
            set { SetProperty(ref _vehicleRentalPrice, value); }
        }

        string _insurancePrice;
        public string InsurancePrice
        {
            get { return _insurancePrice; }
            set { SetProperty(ref _insurancePrice, value); }
        }


        private InsuranceModel _selectedInsuranceType = null;
        public InsuranceModel SelectedInsuranceType
        {
            get { return _selectedInsuranceType; }
            set
            {
                SetProperty(ref _selectedInsuranceType, value);
            }
        }


        string _creditCardNumber;
        public string CreditCardNumber
        {
            get { return _creditCardNumber; }
            set { SetProperty(ref _creditCardNumber, value); }
        }

        string _expiryYear;
        public string ExpiryYear
        {
            get { return _expiryYear; }
            set { SetProperty(ref _expiryYear, value); }
        }

        string _expiryMonth;
        public string ExpiryMonth
        {
            get { return _expiryMonth; }
            set { SetProperty(ref _expiryMonth, value); }
        }

        string _cvc;
        public string CVC
        {
            get { return _cvc; }
            set { SetProperty(ref _cvc, value); }
        }

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            //Load insurance data to drop down list
            if (InsuranceList.Count == 0)
            {
                var insuranceList = await _insuranceService.Get<List<InsuranceModel>>(null);

                foreach (var x in insuranceList)
                {
                    InsuranceList.Add(x);
                }
            }

            var vehicle = await _vehicleService.GetById<OpenRoads.Model.VehicleModel>(_vehicleId);
            var vehicleModelList = await _vehicleModelService.Get<List<OpenRoads.Model.VehicleModelModel>>(null);
            var manufacturerList = await _vehicleManufacturerService.Get<List<VehicleManufacturerModel>>(null);

            //Set the selected vehicle information to display
            foreach (var model in vehicleModelList)
            {
                if (vehicle.VehicleModelId == model.VehicleModelId)
                {
                    foreach (var manufacturer in manufacturerList)
                    {
                        if (model.VehicleManufacturerId == manufacturer.VehicleManufacturerId)
                        {
                            DailyPrice = vehicle.PriceByDay + " KM";
                            HorsePower = vehicle.PowerInHp + " hp";
                            ManufacturedYear = vehicle.ManufacturedYear;
                            VehicleName = manufacturer.Name + " " + model.Name;
                            VehiclePicture = vehicle.Picture;

                            break;
                        }
                    }

                    break;
                }
            }
        }

        public ICommand CreateReservationCommand { get; set; }

        //Create new reservation
        public async Task Create()
        {
            LoggedClient = await _clientService.GetById<ClientModel>(APIService.LoggedUserId);

            string[] totalPrice = TotalPrice.Split('K');
            float.TryParse(totalPrice[0], out float ReservationPrice);

            var newReservationRequest = new ReservationInsertUpdateRequest
            {
                VehicleId = _vehicleId,
                Active = true,
                AdditionalInfo = AdditionalInfo,
                Canceled = false,
                ClientId = LoggedClient.ClientId,
                DateFrom = _startDate,
                DateTo = _endDate,
                CreationDate = DateTime.Now,
                InsuranceId = SelectedInsuranceType.InsuranceId,
                Price = ReservationPrice
            };

            var reservationSuccess = await _reservationService.Insert<ReservationModel>(newReservationRequest);

            if (reservationSuccess != null)
            {
                Application.Current.MainPage = new VehicleOfferView("success", reservationSuccess);
            }

        }
    }
}
