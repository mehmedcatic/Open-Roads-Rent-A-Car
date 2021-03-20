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
    public class CountryController : BaseCRUDController<CountryModel, object, CountryInsertRequest, CountryInsertRequest>
    {
        public CountryController(IBaseCRUDService<CountryModel, object,
            CountryInsertRequest, CountryInsertRequest> service) : base(service)
        {
        }
    }
}
