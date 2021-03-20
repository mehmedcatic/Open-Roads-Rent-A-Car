using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenRoads.Model.Requests;
using OpenRoadsWebAPI.Service;

namespace OpenRoads.API.Controllers
{
    public class VehicleController : BaseCRUDController<OpenRoads.Model.VehicleModel, VehicleSearchRequest,
        VehicleInsertUpdateRequest, VehicleInsertUpdateRequest>
    {
        public VehicleController(IBaseCRUDService<OpenRoads.Model.VehicleModel, VehicleSearchRequest,
            VehicleInsertUpdateRequest, VehicleInsertUpdateRequest> service) : base(service)
        {
        }
    }
}
