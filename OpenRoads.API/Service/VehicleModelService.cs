using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OpenRoads.API.Database;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using VehicleModel = OpenRoads.Model.VehicleModel;

namespace OpenRoadsWebAPI.Service
{
    public class VehicleModelService : BaseCRUDService<VehicleModelModel, VehicleModelSearchRequest, 
        VehicleModel, VehicleModelAddUpdateRequest, VehicleModelAddUpdateRequest>
    {
        public VehicleModelService(openRoadsContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<VehicleModelModel> Get(VehicleModelSearchRequest search)
        {
            var vehicleModels = _context.VehicleModels.ToList();
            var filteredModels = new List<OpenRoads.API.Database.VehicleModel>();

            if (search.VehicleManufacturerId.HasValue)
            {
                foreach (var x in vehicleModels)
                {
                    if (x.VehicleManufacturerId == search.VehicleManufacturerId)
                    {
                        filteredModels.Add(new OpenRoads.API.Database.VehicleModel
                        {
                            Name = x.Name,
                            VehicleManufacturerId = x.VehicleManufacturerId,
                            VehicleModelId = x.VehicleModelId
                        });
                    }
                }

                return _mapper.Map<List<VehicleModelModel>>(filteredModels);
            }

            return _mapper.Map<List<VehicleModelModel>>(vehicleModels);
        }
    }
}
