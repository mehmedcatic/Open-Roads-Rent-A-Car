using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenRoads.API.Helpers;
using OpenRoadsWebAPI.Service;

namespace OpenRoads.API.Controllers
{
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
    {
        private readonly IBaseCRUDService<T, TSearch, TInsert, TUpdate> _service = null;

        public BaseCRUDController(IBaseCRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }


        [HttpPost]
        public virtual T Insert(TInsert request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public virtual T Update(int id, [FromBody] TUpdate request)
        {
            return _service.Update(id, request);
        }

        [Authorize(Roles = HelperClass.adminRole)]
        [HttpDelete("{id}")]
        public T Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
