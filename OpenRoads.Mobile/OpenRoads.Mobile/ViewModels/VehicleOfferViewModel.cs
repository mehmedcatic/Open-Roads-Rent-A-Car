using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenRoads.Mobile;
using OpenRoads.Mobile.ViewModels;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using Xamarin.Forms;

namespace OpenRoads.Mobile.ViewModels
{


    public class VehicleOfferViewModel : BaseViewModel
    {
        public class VehicleToDisplay
        {
            public int VehicleId { get; set; }
            public string VehicleName { get; set; }
            public int ManufacturedYear { get; set; }
            public string DailyPrice { get; set; }
            public string PowerHP { get; set; }
            public byte[] Picture { get; set; }
            public bool Available { get; set; }
        }


        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");
        private readonly APIService _vehicleTransmissionService = new APIService("VehicleTransmissionType");
        private readonly APIService _vehicleFuelService = new APIService("VehicleFuelType");
        private readonly APIService _reservationService = new APIService("Reservation");
        private readonly APIService _recommenderService = new APIService("RecommenderSystem");

        public VehicleOfferViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<VehicleToDisplay> VehicleList { get; set; } = new ObservableCollection<VehicleToDisplay>();
        public ObservableCollection<VehicleToDisplay> RecommendedVehiclesList { get; set; } = new ObservableCollection<VehicleToDisplay>();
        public ObservableCollection<OpenRoads.Model.VehicleFuelTypeModel> VehicleFuelTypeList { get; set; } =
            new ObservableCollection<OpenRoads.Model.VehicleFuelTypeModel>();
        public ObservableCollection<OpenRoads.Model.VehicleTransmissionTypeModel> VehicleTransmissionList { get; set; } =
            new ObservableCollection<VehicleTransmissionTypeModel>();



        VehicleFuelTypeModel _selectedFuelType = null;
        public VehicleFuelTypeModel SelectedFuelType
        {
            get { return _selectedFuelType; }
            set
            {
                SetProperty(ref _selectedFuelType, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        VehicleTransmissionTypeModel _selectedTransmissionType = null;
        public VehicleTransmissionTypeModel SelectedTransmissionType
        {
            get { return _selectedTransmissionType; }
            set
            {
                SetProperty(ref _selectedTransmissionType, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }

        public DateTime _selectedDateFrom;
        public DateTime SelectedDateFrom
        {
            get { return _selectedDateFrom; }
            set
            {
                SetProperty(ref _selectedDateFrom, value);
                if (value != new DateTime(0001, 1, 1))
                {
                    InitCommand.Execute(null);
                }

            }
        }

        public DateTime _selectedDateTo;
        public DateTime SelectedDateTo
        {
            get { return _selectedDateTo; }
            set
            {
                SetProperty(ref _selectedDateTo, value);
                if (value != new DateTime(0001, 1, 1))
                {
                    InitCommand.Execute(null);
                }

            }
        }

       
        public ICommand InitCommand { get; set; }


        private async Task LoadVehicles(VehicleSearchRequest request = null)
        {
            var vehicles = await _vehicleService.Get<List<OpenRoads.Model.VehicleModel>>(request);
            var vehicleManufacturers = await _vehicleManufacturerService.Get<List<VehicleManufacturerModel>>(null);
            var vehicleModels = await _vehicleModelService.Get<List<VehicleModelModel>>(null);
            var reservationsList = await _reservationService.Get<List<ReservationModel>>(null);
            DateTime dateToCheck = new DateTime(0001, 1, 1);

            bool vehicleRented = false;

            VehicleList.Clear();


            foreach (var x in vehicles)
            {
                vehicleRented = false;

                foreach (var reservation in reservationsList)
                {

                    if (reservation.VehicleId == x.VehicleId)
                    {

                        if (SelectedDateTo != dateToCheck)
                        {
                            if (SelectedDateFrom >= reservation.DateFrom && SelectedDateFrom <= reservation.DateTo)
                            {
                                vehicleRented = true;
                            }

                            if ((SelectedDateFrom < reservation.DateFrom && SelectedDateFrom < reservation.DateTo)
                                && (SelectedDateTo >= reservation.DateFrom && SelectedDateTo <= reservation.DateTo))
                            {
                                vehicleRented = true;
                            }

                            if (reservation.DateFrom >= SelectedDateFrom && reservation.DateTo <= SelectedDateTo)
                            {
                                if(reservation.DateTo > DateTime.Now)
                                    vehicleRented = true;
                            }
                        }

                    }
                }

                if (!vehicleRented)
                {

                    VehicleToDisplay newVehicle = new VehicleToDisplay();
                    newVehicle.VehicleId = x.VehicleId;
                    newVehicle.Available = x.Available;
                    newVehicle.Picture = x.Picture;
                    newVehicle.DailyPrice = x.PriceByDay + " KM";
                    newVehicle.PowerHP = x.PowerInHp + " hp";
                    newVehicle.ManufacturedYear = x.ManufacturedYear;

                    foreach (var model in vehicleModels)
                    {
                        if (x.VehicleModelId == model.VehicleModelId)
                        {
                            foreach (var manufacturer in vehicleManufacturers)
                            {
                                if (model.VehicleManufacturerId == manufacturer.VehicleManufacturerId)
                                {
                                    newVehicle.VehicleName = manufacturer.Name + " " + model.Name;
                                    break;
                                }
                            }

                            break;
                        }
                    }
                    VehicleList.Add(newVehicle);
                }

            }
        }

        private async Task LoadRecommendedVehicles(VehicleSearchRequest request = null)
        {
            var vehicleManufacturers = await _vehicleManufacturerService.Get<List<VehicleManufacturerModel>>(null);
            var vehicleModels = await _vehicleModelService.Get<List<VehicleModelModel>>(null);
            var reservationsList = await _reservationService.Get<List<ReservationModel>>(null);
            var recommenderVehicles = await _recommenderService.GetById<List<VehicleModel>>(APIService.LoggedUserId);
            DateTime dateToCheck = new DateTime(0001, 1, 1);

            bool vehicleRented = false;

            RecommendedVehiclesList.Clear();

            if (recommenderVehicles.Count <= 3)
            {
                foreach (var x in recommenderVehicles)
                {
                    vehicleRented = false;

                    foreach (var reservation in reservationsList)
                    {

                        if (reservation.VehicleId == x.VehicleId)
                        {

                            if (SelectedDateTo != dateToCheck)
                            {
                                if (SelectedDateFrom >= reservation.DateFrom && SelectedDateFrom <= reservation.DateTo)
                                {
                                    vehicleRented = true;
                                }

                                if ((SelectedDateFrom < reservation.DateFrom && SelectedDateFrom < reservation.DateTo)
                                    && (SelectedDateTo >= reservation.DateFrom && SelectedDateTo <= reservation.DateTo))
                                {
                                    vehicleRented = true;
                                }

                                if (reservation.DateFrom >= SelectedDateFrom && reservation.DateTo <= SelectedDateTo)
                                {
                                    if (reservation.DateTo > DateTime.Now)
                                        vehicleRented = true;
                                }
                            }

                        }
                    }

                    if (!vehicleRented)
                    {

                        VehicleToDisplay newVehicle = new VehicleToDisplay();
                        newVehicle.VehicleId = x.VehicleId;
                        newVehicle.Available = x.Available;
                        newVehicle.Picture = x.Picture;
                        newVehicle.DailyPrice = x.PriceByDay + " KM";
                        newVehicle.PowerHP = x.PowerInHp + " hp";
                        newVehicle.ManufacturedYear = x.ManufacturedYear;

                        foreach (var model in vehicleModels)
                        {
                            if (x.VehicleModelId == model.VehicleModelId)
                            {
                                foreach (var manufacturer in vehicleManufacturers)
                                {
                                    if (model.VehicleManufacturerId == manufacturer.VehicleManufacturerId)
                                    {
                                        newVehicle.VehicleName = manufacturer.Name + " " + model.Name;
                                        break;
                                    }
                                }

                                break;
                            }
                        }
                        RecommendedVehiclesList.Add(newVehicle);
                    }

                }
            }
            
        }

        public async Task Init()
        {
            if (VehicleFuelTypeList.Count == 0)
            {
                var vfList = await _vehicleFuelService.Get<List<VehicleFuelTypeModel>>(null);

                foreach (var x in vfList)
                {
                    VehicleFuelTypeList.Add(x);
                }
            }

            if (VehicleTransmissionList.Count == 0)
            {
                var vtList = await _vehicleTransmissionService.Get<List<VehicleTransmissionTypeModel>>(null);

                foreach (var x in vtList)
                {
                    VehicleTransmissionList.Add(x);
                }
            }

            if (SelectedFuelType != null || SelectedTransmissionType != null)
            {
                VehicleSearchRequest request = new VehicleSearchRequest();
                if (SelectedFuelType != null)
                    request.VehicleFuelTypeId = SelectedFuelType.VehicleFuelTypeId;
                if (SelectedTransmissionType != null)
                    request.VehicleTransmissionTypeId = SelectedTransmissionType.VehicleTransmissionTypeId;

                await LoadVehicles(request);
                await LoadRecommendedVehicles(request);
            }

            if (SelectedFuelType == null && SelectedTransmissionType == null)
            {
                await LoadVehicles();
                await LoadRecommendedVehicles();
            }


        }
    }
}
