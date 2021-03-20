using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OpenRoads.API.Database;
using OpenRoads.Model.Requests;


namespace OpenRoadsWebAPI.Service
{
    public class VehicleService : BaseCRUDService<OpenRoads.Model.VehicleModel, VehicleSearchRequest, Vehicle, 
        VehicleInsertUpdateRequest, VehicleInsertUpdateRequest>
    {
        public VehicleService(openRoadsContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override OpenRoads.Model.VehicleModel Delete(int id)
        {
            var entity = _context.Vehicles.FirstOrDefault(x => x.VehicleId == id);

            if (entity != null)
            {
                entity.Active = false;
                _context.SaveChanges();
            }

            return _mapper.Map<OpenRoads.Model.VehicleModel>(entity);
        }


        private List<Vehicle> FilterVehicles(int? manufacturerId, int? fuelId, int? transmissionId, List<Vehicle> vehicles)
        {
            List<Vehicle> listOfVehicles = new List<Vehicle>();

            bool manufacturerFound = false;
            bool fuelFound = false;
            bool transmissionFound = false;

            List<VehicleManufacturer> manufacturers;
            List<OpenRoads.API.Database.VehicleModel> models;

            if (manufacturerId.HasValue)
            {
                models = _context.VehicleModels.Where(x => x.VehicleManufacturerId == manufacturerId).ToList();
                manufacturers = _context.VehicleManufacturers.Where(x => x.VehicleManufacturerId == manufacturerId)
                    .ToList();
            }
            else
            {
                models = _context.VehicleModels.ToList();
                manufacturers = _context.VehicleManufacturers.ToList();
            }

            foreach (var x in vehicles)
            {
                var newVehicle = new Vehicle();
                
                if (manufacturerId.HasValue)
                {
                    foreach (var y in models)
                    {
                        if (x.VehicleModelId == y.VehicleModelId)
                        {
                            foreach (var z in manufacturers)
                            {
                                if (y.VehicleManufacturerId == z.VehicleManufacturerId)
                                {
                                    if (z.VehicleManufacturerId == manufacturerId)
                                    {
                                        manufacturerFound = true;
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
                else
                {
                    manufacturerFound = true;
                }

                if (transmissionId.HasValue)
                {
                    if (x.VehicleTransmissionTypeId == transmissionId)
                        transmissionFound = true;
                }
                else
                {
                    transmissionFound = true;
                }

                if (fuelId.HasValue)
                {
                    if (x.VehicleFuelTypeId == fuelId)
                        fuelFound = true;
                }
                else
                {
                    fuelFound = true;
                }

                if (fuelFound && transmissionFound && manufacturerFound)
                {
                    newVehicle = _mapper.Map<Vehicle>(x);
                    listOfVehicles.Add(newVehicle);
                }
                fuelFound = false;
                transmissionFound = false;
                manufacturerFound = false;

            }




            return listOfVehicles;
        }

        public override List<OpenRoads.Model.VehicleModel> Get(VehicleSearchRequest search)
        {
            var query = _context.Vehicles.Where(x => x.Active == true).ToList();

            if (search.VehicleManufacturerId.HasValue && search.VehicleFuelTypeId.HasValue
                                                      && search.VehicleTransmissionTypeId.HasValue)
            {
                var list = FilterVehicles(search.VehicleManufacturerId, search.VehicleFuelTypeId,
                    search.VehicleTransmissionTypeId, query);

                return _mapper.Map<List<OpenRoads.Model.VehicleModel>>(list);
            }
            if (search.VehicleManufacturerId.HasValue && search.VehicleFuelTypeId.HasValue
                                                      && search.VehicleTransmissionTypeId.HasValue == false)
            {
                var list = FilterVehicles(search.VehicleManufacturerId, search.VehicleFuelTypeId, null, query);

                return _mapper.Map<List<OpenRoads.Model.VehicleModel>>(list);
            }
            if (search.VehicleManufacturerId.HasValue && search.VehicleFuelTypeId.HasValue == false
                                                      && search.VehicleTransmissionTypeId.HasValue)
            {
                var list = FilterVehicles(search.VehicleManufacturerId, null, search.VehicleTransmissionTypeId, query);

                return _mapper.Map<List<OpenRoads.Model.VehicleModel>>(list);
            }
            if (search.VehicleManufacturerId.HasValue == false && search.VehicleFuelTypeId.HasValue
                                                      && search.VehicleTransmissionTypeId.HasValue)
            {
                var list = FilterVehicles(null, search.VehicleFuelTypeId, search.VehicleTransmissionTypeId, query);

                return _mapper.Map<List<OpenRoads.Model.VehicleModel>>(list);
            }
            if (search.VehicleManufacturerId.HasValue && search.VehicleFuelTypeId.HasValue == false
                                                      && search.VehicleTransmissionTypeId.HasValue == false)
            {
                var list = FilterVehicles(search.VehicleManufacturerId, null, null, query);

                return _mapper.Map<List<OpenRoads.Model.VehicleModel>>(list);
            }
            if (search.VehicleManufacturerId.HasValue == false && search.VehicleFuelTypeId.HasValue
                                                      && search.VehicleTransmissionTypeId.HasValue == false)
            {
                var list = FilterVehicles(null, search.VehicleFuelTypeId, null, query);

                return _mapper.Map<List<OpenRoads.Model.VehicleModel>>(list);
            }
            if (search.VehicleManufacturerId.HasValue == false && search.VehicleFuelTypeId.HasValue == false
                                                      && search.VehicleTransmissionTypeId.HasValue)
            {
                var list = FilterVehicles(null, null, search.VehicleTransmissionTypeId, query);

                return _mapper.Map<List<OpenRoads.Model.VehicleModel>>(list);
            }

            return _mapper.Map<List<OpenRoads.Model.VehicleModel>>(query);
        }
    }
}
