using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenRoadsWebAPI.Service;

namespace OpenRoads.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecommenderSystemController : ControllerBase
    {
        private readonly IRecommenderService _service;

        public RecommenderSystemController(IRecommenderService service)
        {
            _service = service;
        }


        [HttpGet("{id}")]
        public List<OpenRoads.Model.VehicleModel> GetVehicleRecommendation(int id)
        {
            return _service.GetVehicleRecommendation(id);
        }
    }
}
