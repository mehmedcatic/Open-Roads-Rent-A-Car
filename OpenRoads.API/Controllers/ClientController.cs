using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenRoads.API.Helpers;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using OpenRoadsWebAPI.Service;

namespace OpenRoads.API.Controllers
{
    public class ClientController : BaseCRUDController<ClientModel, ClientSearchRequest, ClientUpdateRequest, ClientUpdateRequest>
    {
        public ClientController(IBaseCRUDService<ClientModel, ClientSearchRequest, ClientUpdateRequest, ClientUpdateRequest> service) : base(service)
        {
        }

        [Authorize(Roles = HelperClass.adminRole + "," + HelperClass.clientRole)]
        public override ClientModel Update(int id, ClientUpdateRequest request)
        {
            return base.Update(id, request);
        }
    }
}
