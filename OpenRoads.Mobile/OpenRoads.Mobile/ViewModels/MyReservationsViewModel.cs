using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class MyReservationsViewModel : BaseViewModel
    {
        private readonly APIService _clientService = new APIService("Client");
        private readonly APIService _reservationService = new APIService("Reservation");
        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");
        private readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");


        //Since reservation object has his vital info spread through other objects such as Vehicle, and Vehicle through reference tables like VehicleModel
        // VehicleMnaufacturer and so on, we created the new ReservationToDisplay class in which we'll set the attributes we want to display in UI
        public class ReservationToDisplay
        {
            public int ReservationId { get; set; }
            public string DateFrom { get; set; }
            public string DateTo { get; set; }
            public string Price { get; set; }
            public string CreationDate { get; set; }
            public bool Active { get; set; }
            public int ClientId { get; set; }
            public string VehicleName { get; set; }
            public byte[] VehiclePicture { get; set; }
        }



        public MyReservationsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<ReservationToDisplay> ReservationActiveList { get; set; } = new ObservableCollection<ReservationToDisplay>();
        public ObservableCollection<ReservationToDisplay> ReservationFinishedList { get; set; } = new ObservableCollection<ReservationToDisplay>();



        public ICommand InitCommand { get; set; }


        //Loop through all vehicles in the db in search for the one that's contained in the reservation (reservationVehicleId) and set it's properties
        private void AddVehicleAttrs(ReservationToDisplay obj, List<VehicleModel> vehicleList, List<VehicleModelModel> vehicleModelList,
            List<VehicleManufacturerModel> vehicleManufacturersList, int reservationVehicleId)
        {
            foreach (var vehicle in vehicleList)
            {
                if (reservationVehicleId == vehicle.VehicleId)
                {
                    foreach (var model in vehicleModelList)
                    {
                        if (vehicle.VehicleModelId == model.VehicleModelId)
                        {
                            foreach (var manufacturer in vehicleManufacturersList)
                            {
                                if (model.VehicleManufacturerId == manufacturer.VehicleManufacturerId)
                                {
                                    obj.VehicleName = manufacturer.Name + " " + model.Name;
                                    obj.VehiclePicture = vehicle.Picture;
                                    break;
                                }
                            }

                            break;
                        }

                    }

                    break;
                }
            }
        }

        private async Task LoadReservations()
        {
            try
            {
                var client = await _clientService.GetById<ClientModel>(APIService.LoggedUserId);

                var request = new ReservationSearchRequest();
                request.ClientId = client.ClientId;
                var reservations = await _reservationService.Get<List<ReservationModel>>(request);

                var vehicleList = await _vehicleService.Get<List<OpenRoads.Model.VehicleModel>>(null);
                var vehicleModelList = await _vehicleModelService.Get<List< OpenRoads.Model.VehicleModelModel >>(null);
                var vehicleManufacturersList =
                    await _vehicleManufacturerService.Get<List<VehicleManufacturerModel>>(null);


                //Loop through client reservations
                foreach (var reservation in reservations)
                {
                    //If canceled don't consider it
                    if (!reservation.Canceled)
                    {
                        //Check if finished else it's active
                        if (reservation.DateTo < DateTime.Now)
                        {
                            ReservationToDisplay newFinishedRes = new ReservationToDisplay
                            {
                                ReservationId = reservation.ReservationId,
                                ClientId = client.ClientId,
                                Active = reservation.Active,
                                CreationDate = reservation.CreationDate.ToString("dd.MM.yyyy"),
                                DateFrom = reservation.DateFrom.ToString("dd.MM.yyyy"),
                                DateTo = reservation.DateTo.ToString("dd.MM.yyyy"),
                                Price = reservation.Price + "KM"
                            };

                            AddVehicleAttrs(newFinishedRes, vehicleList, vehicleModelList, vehicleManufacturersList, reservation.VehicleId);

                            ReservationFinishedList.Add(newFinishedRes);
                        }
                        else
                        {
                            ReservationToDisplay newActiveRes = new ReservationToDisplay
                            {
                                ReservationId = reservation.ReservationId,
                                ClientId = client.ClientId,
                                Active = reservation.Active,
                                CreationDate = reservation.CreationDate.ToString("dd.MM.yyyy"),
                                DateFrom = reservation.DateFrom.ToString("dd.MM.yyyy"),
                                DateTo = reservation.DateTo.ToString("dd.MM.yyyy"),
                                Price = reservation.Price + "KM"
                            };

                            AddVehicleAttrs(newActiveRes, vehicleList, vehicleModelList, vehicleManufacturersList, reservation.VehicleId);

                            ReservationActiveList.Add(newActiveRes);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Init()
        {
            await LoadReservations();
        }
    }
}
