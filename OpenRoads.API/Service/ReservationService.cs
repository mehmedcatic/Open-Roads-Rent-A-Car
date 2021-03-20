using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OpenRoads.API.Database;
using OpenRoads.Model;
using OpenRoads.Model.Requests;

namespace OpenRoadsWebAPI.Service
{
    public class ReservationService : BaseCRUDService<ReservationModel, ReservationSearchRequest, Reservation, 
        ReservationInsertUpdateRequest, ReservationInsertUpdateRequest>
    {
        public ReservationService(openRoadsContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override List<ReservationModel> Get(ReservationSearchRequest search)
        {
            var query = _context.Reservations.ToList();

            List<Reservation> reservationList = new List<Reservation>();

            if (search.InsuranceId.HasValue && search.VehicleId.HasValue)
            {
                foreach (var x in query)
                {
                    if(x.InsuranceId == search.InsuranceId && x.VehicleId == search.VehicleId)
                        reservationList.Add(x);
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }

            if (search.InsuranceId.HasValue && search.VehicleId.HasValue == false)
            {
                foreach (var x in query)
                {
                    if (x.InsuranceId == search.InsuranceId)
                        reservationList.Add(x);
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }

            if (search.InsuranceId.HasValue == false && search.VehicleId.HasValue)
            {
                foreach (var x in query)
                {
                    if (x.VehicleId == search.VehicleId)
                        reservationList.Add(x);
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }


            var vehicles = _context.Vehicles.ToList();
            var vehicleManufacturers = _context.VehicleManufacturers.ToList();
            var vehicleModels = _context.VehicleModels.ToList();

            if (search.ReservationYear.HasValue && search.VehicleManufacturerId.HasValue)
            {
                foreach (var x in query)
                {
                    if (x.DateFrom.Year == search.ReservationYear)
                    {
                        foreach (var vehicle in vehicles)
                        {
                            if (vehicle.VehicleId == x.VehicleId)
                            {
                                foreach (var model in vehicleModels)
                                {
                                    if (model.VehicleModelId == vehicle.VehicleModelId &&
                                        model.VehicleManufacturerId == search.VehicleManufacturerId)
                                    {
                                        reservationList.Add(x);
                                        break;
                                    }
                                }

                                break;
                            }
                        }
                    }
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }

            if (search.ReservationYear.HasValue && search.VehicleManufacturerId.HasValue == false)
            {
                foreach (var x in query)
                {
                    if (x.DateFrom.Year == search.ReservationYear)
                        reservationList.Add(x);
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }

            if (search.ReservationYear.HasValue == false && search.VehicleManufacturerId.HasValue)
            {
                foreach (var x in query)
                {
                    foreach (var vehicle in vehicles)
                    {
                        if (vehicle.VehicleId == x.VehicleId)
                        {
                            foreach (var model in vehicleModels)
                            {
                                if (model.VehicleModelId == vehicle.VehicleModelId &&
                                    model.VehicleManufacturerId == search.VehicleManufacturerId)
                                {
                                    reservationList.Add(x);
                                    break;
                                }
                            }

                            break;
                        }
                    };
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }



            if (search.ClientId.HasValue)
            {
                foreach (var x in query)
                {
                    if(x.ClientId == search.ClientId)
                        reservationList.Add(x);
                }

                return _mapper.Map<List<ReservationModel>>(reservationList);
            }


            return _mapper.Map<List<ReservationModel>>(query);
        }

        
    }
}
