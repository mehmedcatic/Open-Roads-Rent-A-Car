using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using OpenRoadsWebAPI.Service;

namespace OpenRoads.API.Controllers
{
    public class ReservationController : BaseCRUDController<ReservationModel, ReservationSearchRequest,
        ReservationInsertUpdateRequest, ReservationInsertUpdateRequest>
    {
        public ReservationController(IBaseCRUDService<ReservationModel, ReservationSearchRequest,
            ReservationInsertUpdateRequest, ReservationInsertUpdateRequest> service) : base(service)
        {
        }
    }
}
